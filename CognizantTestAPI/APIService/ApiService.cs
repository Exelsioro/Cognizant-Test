using ClientFunctionExecutor;
using DataProvider;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService
{
    public class ApiService
    {
        private DataBaseProvider dataAcces = new DataBaseProvider();
        public List<TaskModel> GetTaskList()
        {
            return dataAcces.GetTaskList();
        }
        public TaskDescriptionAndParams GetTaskDescriptionAndParams(int id)
        {
            return dataAcces.GetTaskDescriptionAndParamsById(id);
        }
        public List<PlayerStatisticModel> GetStatistic()
        {
            return dataAcces.GetStatistics();
        }
        public ResultModel SolvePlayerSolution(CompletedTaskModel data)
        {
            FunctionExecutor fe = new FunctionExecutor(new ExecuteLogHandler(Log));

            var correctData = dataAcces.GetTaskDataToCompare(data.SelectedTaskId);
            string solutionString = CheckReturn(data.SolutionString);
            correctData.taskSolution = CheckReturn(correctData.taskSolution);
            ExecuteFunction(solutionString, correctData.taskPatams, fe);
            var userOutput = this.output;
            this.output = string.Empty;
            ExecuteFunction(correctData.taskSolution, correctData.taskPatams, fe);
            var correctOutput = this.output;
            CheckedSolutionModel resultModel = null;
            if (userOutput.Equals(correctOutput))
            {
                resultModel = new CheckedSolutionModel(data.Name, data.SelectedTaskId, data.SolutionString, true);
            }
            else
            {
                resultModel = new CheckedSolutionModel(data.Name, data.SelectedTaskId, data.SolutionString, false);
            }
            dataAcces.pushCheckedSolution(resultModel);
            return new ResultModel(userOutput.ToLower().Contains("error") ? userOutput.Split(new string[] { "error" }, StringSplitOptions.None).LastOrDefault() : userOutput, resultModel.isSolvedCrrectly);
        }

        private string output;

        private void ExecuteFunction(string function, string parameters, FunctionExecutor fe)
        {
            fe.FormatSources(function, parameters);
            fe.Execute();
        }
        private void Log(object msg)
        {

            output += msg;
        }
        private string CheckReturn(string command)
        {
            string resStr = string.Empty;
            if (command.ToLower().Contains("return"))
            {
                var tempStr = command.Replace("return", "Log(");
                resStr = tempStr.Insert(tempStr.Length - 1, ")");
            }
            else
            {
                resStr = command;
            }
            return resStr;
        }

    }
}

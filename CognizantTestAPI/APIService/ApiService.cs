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
        public void SolvePlayerSolution(CompletedTaskModel data)
        {
           
        }

    }
}

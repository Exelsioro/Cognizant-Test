using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class DataBaseProvider
    {
        public List<TaskModel> GetTaskList()
        {
            List<TaskModel> result = new List<TaskModel>();
            using (var context = new Cognizant_TestEntities())
            {
                var query = context.Task;
                foreach (var task in query)
                {
                    result.Add(new TaskModel(task.Id, task.TaskName));
                }
            }
            return result;
        }
        public TaskDescriptionAndParams GetTaskDescriptionAndParamsById(int id)
        {
            TaskDescriptionAndParams result;
            using (var context = new Cognizant_TestEntities())
            {
                var query = context.Task.Where(t => t.Id == id).FirstOrDefault();
                if(query == null)
                {
                    result = new TaskDescriptionAndParams();
                } else
                {
                   result = new TaskDescriptionAndParams(query.TaskTestingParameters, query.TaskDescription);
                }
            }
            return result;
        }

        public TaskDataToCompare GetTaskDataToCompare(int id)
        {
            TaskDataToCompare result;
            using (var context = new Cognizant_TestEntities())
            {
                var query = context.Task.Where(t => t.Id == id).FirstOrDefault();
                result = new TaskDataToCompare(query.TaskTestingParameters, query.TaskSolution);
            }
            return result;
        }

        public List<PlayerStatisticModel> GetStatistics()
        {
            List<PlayerStatisticModel> result = new List<PlayerStatisticModel>();
            using (var context = new Cognizant_TestEntities())
            {
                var players = context.Player.Select(p => p.Id);
                List<List<TaskSolutions>> playersResults = new List<List<TaskSolutions>>();
                foreach (var p in players)
                {
                    var playerResult = context.TaskSolutions.Where(pl => pl.PlayerId == p && pl.IsSolutionCorrect == true).ToList();
                    var playerResultUnique = playerResult.GroupBy(x => x.TaskId).Select(y => y.First());
                    playersResults.Add(playerResultUnique.ToList());
                }
                playersResults = playersResults.OrderByDescending(pl => pl.Count).Take(3).ToList();
                foreach (var p in playersResults)
                {
                    var player = new PlayerStatisticModel();
                    player.countSolved = p.Count;
                    var playerId = p[0].PlayerId;
                    player.playerName = context.Player.Where(pl => pl.Id == playerId).FirstOrDefault().Name;
                    List<string> taskNames = new List<string>();
                    foreach (var task in p)
                    {
                        var taskId = task.TaskId;
                        var DBtask = context.Task.Where(t => t.Id == taskId).FirstOrDefault();
                        var taskName = DBtask.TaskName;
                        taskNames.Add(taskName);
                    }
                    player.namesSolved = taskNames;
                    result.Add(player);
                }
            }
            return result.OrderByDescending(p => p.countSolved).ToList();
        }

        public void pushCheckedSolution(CheckedSolutionModel model)
        {
            Player player;
            using (var context = new Cognizant_TestEntities())
            {
                player = context.Player.Where(p => p.Name == model.playerName).FirstOrDefault();
                if (player == null)
                {
                    context.Player.Add(new Player() { Name = model.playerName });
                    context.SaveChanges();
                    player = context.Player.Where(p => p.Name == model.playerName).FirstOrDefault();
                }
                TaskSolutions solved = new TaskSolutions()
                {
                    IsSolutionCorrect = model.isSolvedCrrectly,
                    PlayerId = player.Id,
                    PlayerTaskSolution = model.playerTaskSolution,
                    TaskId = model.taskId
                };
                context.TaskSolutions.Add(solved);
                context.SaveChanges();
            }
        }
    }
}

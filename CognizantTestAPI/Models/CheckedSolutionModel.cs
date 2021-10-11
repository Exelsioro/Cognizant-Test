using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CheckedSolutionModel
    {
        public string playerName;
        public int taskId;
        public string playerTaskSolution;
        public bool isSolvedCrrectly;
        public CheckedSolutionModel(string playerName, int taskId, string playerTaskSolution, bool isSolvedCrrectly)
        {
            this.playerName = playerName;
            this.taskId = taskId;
            this.playerTaskSolution = playerTaskSolution;
            this.isSolvedCrrectly = isSolvedCrrectly;
        }
    }
}
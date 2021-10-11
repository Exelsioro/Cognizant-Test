using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaskDataToCompare
    {
        public string taskPatams;
        public string taskSolution;
        public TaskDataToCompare(string param, string solution)
        {
            this.taskPatams = param;
            this.taskSolution = solution;
        }
    }
}
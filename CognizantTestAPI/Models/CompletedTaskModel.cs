using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CompletedTaskModel
    {
        public string Name { get; set; }
        public int SelectedTaskId { get; set; }
        public string SolutionString { get; set; }
    }
}
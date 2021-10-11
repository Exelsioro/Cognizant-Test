using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaskDescriptionAndParams
    {
        public string parameters;
        public string description;
        public TaskDescriptionAndParams(string par, string des)
        {
            this.parameters = par;
            this.description = des;
        }
        public TaskDescriptionAndParams()
        {
            this.parameters = string.Empty;
            this.description = string.Empty;
        }
    }
}
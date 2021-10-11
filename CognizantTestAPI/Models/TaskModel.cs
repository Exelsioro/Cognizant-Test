using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaskModel
    {
        public int id;
        public string Name;
        public TaskModel(int id, string Name)
        {
            this.id = id;
            this.Name = Name;
        }
    }
}
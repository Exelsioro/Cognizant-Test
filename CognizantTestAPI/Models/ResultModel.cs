using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ResultModel
    {
        public string result;
        public bool isCorrect;
        public ResultModel()
        {
            result = string.Empty;
            isCorrect = false;
        }
        public ResultModel(string result, bool isCorrect)
        {
            this.result = result;
            this.isCorrect = isCorrect;
        }
    }
}

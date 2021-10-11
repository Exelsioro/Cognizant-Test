using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlayerStatisticModel
    {
        public string playerName;
        public int countSolved;
        public List<string> namesSolved;
        public PlayerStatisticModel(string playerName, int count, List<string> names)
        {
            this.playerName = playerName;
            this.countSolved = count;
            this.namesSolved = names;
        }
        public PlayerStatisticModel()
        {
            this.playerName = string.Empty;
            this.countSolved = 0;
            this.namesSolved = new List<string>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_1
{
    public class Group
    {
        public List<int> Values { get; set; } = new List<int>();

        public int GetTotal()
        {
            return Values.Sum();
        }
    }
}

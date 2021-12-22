using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GreetingPoco
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int status { get; set; }
        public string fullname { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public GreetingPoco(string first, string last, int stat)
        {
            firstname = first;
            lastname = last;
            status = stat;
        }
    }
}

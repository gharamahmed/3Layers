using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace register
{
    internal class Department
    {
        public int dept_Id { get; set; }
        public string dept_Name { get; set; }
        public string dept_Desc { get; set; }
        public string location { get; set; }
        public int ? dept_manager { get; set; }
        public string hiredate { get; set; }
    }
}

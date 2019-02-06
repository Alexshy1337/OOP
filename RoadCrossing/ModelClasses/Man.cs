using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class Man
    {
        public bool CanMove { get; set; }
        public bool ToptoDown { get; set; }
        public int Y { get; set; }

        public Man()
        {
            Y = 0;
        }

    }
}

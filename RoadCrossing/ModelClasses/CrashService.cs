using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class CrashService : ICrashService
    {
        public bool IsLoaded { get; set; }
        public bool LeftToRight { get; set; }
        public int X { get; set; }
        public delegate void CrashTarget(Car sender);
        public CrashTarget onCrash;


        public void CleanUp()
        {
            throw new NotImplementedException();
        }


    }
}

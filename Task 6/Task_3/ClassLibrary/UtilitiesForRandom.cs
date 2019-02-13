using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UtilitiesForRandom
    {
        static Random r = new Random();

        public static bool RandomLocked()
        {
            int i = r.Next(0, 2);
            if (i == 0) return true;
            return false;
        }









    }
}

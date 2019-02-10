using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ModelClasses
{
    public class Man
    {
        public bool CanMove { get; set; }
        public bool ToptoBottom { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public int ObstacleY { get; set; }
        public Thread CurThread { get; set; }

        public Man()
        {
            Y = 340;
            CurThread = new Thread(new ThreadStart(Walk));
        }

        public Man(bool toptobottom)
        {
            Y = toptobottom ? -30 : 340;
            ToptoBottom = toptobottom;
            CurThread = new Thread(new ThreadStart(Walk));
        }

        void Walk()
        {
            int i;
            i = ToptoBottom ? 1 : -1;
            while (true)
            {
                if (CanMove)
                    Y += 5 * i;


                Thread.Sleep(20);
            }
        }

    }
}

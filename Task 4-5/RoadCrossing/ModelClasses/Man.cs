using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ModelClasses
{
    public class Man
    {
        public bool CanMove { get; set; } = true;
        public bool ToptoBottom { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public int ObstacleY { get; set; }
        public Thread CurThread { get; set; }

        public Man(bool movable)
        {
            Y = 340;
            CanMove = movable;
            CurThread = new Thread(new ThreadStart(Walk));
            CurThread.Start();
        }

        public Man(bool toptobottom, bool movable)
        {
            Y = toptobottom ? -30 : 340;
            ToptoBottom = toptobottom;
            CanMove = movable;
            CurThread = new Thread(new ThreadStart(Walk));
            CurThread.Start();
        }

        void Walk()
        {
            int i;
            i = ToptoBottom ? 1 : -1;
            while (true)
            {
                if (CanMove)
                    Y += 3 * i;


                Thread.Sleep(20);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ModelClasses
{
    public class Car
    {
        public bool CanMove { get; set; }
        public bool LeftToRight { get; set; }
        public bool IsBrocken { get; set; }
        public int X { get; set; }
        public int ObstacleX { get; set; }
        public Thread CurThread { get; set; }

        public Car()
        {
            X = -100;
            CurThread = new Thread(new ThreadStart(Ride));
        }

        public Car(bool lefttoright)
        {
            LeftToRight = lefttoright;
            X = lefttoright ? -100 : 420;
            CurThread = new Thread(new ThreadStart(Ride));
        }

        void Ride()
        {
            int i;
            i = LeftToRight ? 1 : -1;
            while(true)
            {
                Thread.Sleep(20);
                if (CanMove)
                    X += 5 * i;

            }
        }
    }
}

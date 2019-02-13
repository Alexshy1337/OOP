using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ModelClasses
{
    public class Car
    {
        public bool CanMove { get; set; } = true;
        public bool LeftToRight { get; set; }
        public bool IsBrocken { get; set; }
        public int X { get; set; }
        public int ObstacleX { get; set; }
        public Thread CurThread { get; set; }

        public Car(bool movable)
        {
            X = -100;
            CanMove = movable;
            CurThread = new Thread(new ThreadStart(Ride));
            CurThread.Start();
        }

        public Car(bool lefttoright, bool movable)
        {
            LeftToRight = lefttoright;
            X = lefttoright ? -100 : 420;
            CanMove = movable;
            CurThread = new Thread(new ThreadStart(Ride));
            CurThread.Start();
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

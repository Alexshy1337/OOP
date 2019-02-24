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
        public bool DontCare { get; set; }
        public bool LeftToRight { get; set; }
        public bool IsBrocken { get; set; }
        public int X { get; set; }
        public Thread CurThread { get; set; }

        public Car(bool movable)
        {
            X = -130;
            LeftToRight = true;
            CanMove = movable;
            CurThread = new Thread(new ThreadStart(Ride));
            CurThread.Start();
        }

        public Car(bool lefttoright, bool movable)
        {
            LeftToRight = lefttoright;
            X = lefttoright ? -130 : 600;
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
                if (CanMove || DontCare || LeftToRight && X < 0 || X > 316 && !LeftToRight)
                    X += 5 * i;
                if (LeftToRight && X > 10 || !LeftToRight && X < 310)
                    DontCare = true;
                if (X > 1000 || X < -1000)
                    CurThread.Abort();
            }
        }

        public void ChangeState()
        {
            CanMove = !CanMove;
        }
    }
}

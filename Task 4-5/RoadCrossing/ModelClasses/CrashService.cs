using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ModelClasses
{
    public class CrashService : ICrashService
    {
        public bool IsInFrame { get; set; }
        public int X { get; set; }
        private Thread CurThread { get; set; }
        public delegate void CrashTarget();
        public CrashTarget onCrash;

        public CrashService()
        {
            X = -500;
            CurThread = new Thread(new ThreadStart(Work));
            CurThread.Start();
        }

        public void Work()
        {
            while(true)
            {
                Thread.Sleep(900);
                if (onCrash != null)
                {
                    lock(this)
                    {
                        onCrash();
                        X = -500;
                    }
                }
            }



        }

        public void Stop()
        {
            CurThread.Abort();
        }

    }
}

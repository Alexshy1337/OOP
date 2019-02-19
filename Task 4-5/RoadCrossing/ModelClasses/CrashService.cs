using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ModelClasses
{
    public class CrashService : ICrashService
    {
        public bool IsLoaded { get; set; }
        public bool LeftToRight { get; set; }
        public int X { get; set; }
        private Thread CurThread { get; set; }
        public delegate void CrashTarget();
        public CrashTarget onCrash;

        public CrashService()
        {
            CurThread = new Thread(new ThreadStart(CleanUp));

        }

        public void CleanUp()
        {
            while(true)
            {
                if (onCrash != null)
                {
                    lock(this)
                    {
                        onCrash();
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

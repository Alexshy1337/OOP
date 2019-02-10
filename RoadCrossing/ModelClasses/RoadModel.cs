using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ModelClasses
{
    public class RoadModel
    {
        Random r { get; set; } = new Random();
        DateTime StartTime { get; set; }
        public bool CurLight { get; set; } = false; //red light
        public Drawer DrawUnit { get; set; }
        public List<Car> Cars { get; set; }
        public List<Man> Ppl { get; set; }
        Thread UpdThread { get; set; }
        Thread AddThread { get; set; }
        event Action GreenLightEvent; //for walkers
        event Action CrashEvent; //car with car only
        

        public RoadModel(DateTime start)
        {
            StartTime = start;
            DrawUnit = new Drawer();
            Cars = new List<Car>();
            Ppl = new List<Man>();
            UpdThread = new Thread(new ThreadStart(Simulation));
            AddThread = new Thread(new ThreadStart(Additions));
        }

        void Additions()
        {
            while(true)
            {
                if (Cars.Count < 4 && r.Next(0, 1000) > 500)
                    Cars.Add(new Car( r.Next(0, 1000) > 500));
                Thread.Sleep(1200);
                if (Ppl.Count < 4 && r.Next(0, 1000) > 500)
                    Ppl.Add(new Man( r.Next(0, 1000) > 500) { X = r.Next(162, 260) });
                Thread.Sleep(1500);
            }
        }

        void Simulation()
        {
            while(true)
            {
                if(Ppl.Count > 1)
                    CheckPplCollisions();
                if(Cars.Count > 1)
                    CheckCarCollisions();

                Thread.Sleep(10);
            }
        }

        void CheckCarCollisions()
        {

        }

        void CheckPplCollisions()
        {

        }

        void StopSimulation()
        {
            UpdThread.Abort();
            AddThread.Abort();
            foreach(Car c in Cars)
                c.CurThread.Abort();
            foreach (Man m in Ppl)
                m.CurThread.Abort();
        }
    }
}

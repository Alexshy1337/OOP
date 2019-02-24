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
        private Random r { get; set; } = new Random();
        public bool CurLight { get; set; }
        public bool HasCrash { get; set; }
        private int LightTimer { get; set; } = 0;
        public Drawer DrawUnit { get; set; }
        public List<Car> Cars { get; set; }
        public List<Man> Ppl { get; set; }
        private Thread UpdThread { get; set; }
        private Thread AddThread { get; set; }
        event Action LightChangedEvent;

        public RoadModel(CrashService cs)
        {
            Cars = new List<Car>();
            Ppl = new List<Man>();
            DrawUnit = new Drawer(Cars, Ppl, cs);
            LightChangedEvent += DrawUnit.ChangeLight;
            UpdThread = new Thread(new ThreadStart(Update));
            AddThread = new Thread(new ThreadStart(Additions));
            UpdThread.Start();
            AddThread.Start();
        }

        void Additions()
        {
            while(true)
            {
                if (Cars.Count < 6 && r.Next(0, 1000) > 500 && !HasCrash)
                {
                    Cars.Add(new Car(r.Next(0, 1000) > 500, !CurLight));
                    LightChangedEvent += Cars.Last().ChangeState;
                }
                Thread.Sleep(1000);

                if (Ppl.Count < 4 && r.Next(0, 1000) > 500 && !HasCrash)
                {
                    Ppl.Add(new Man(r.Next(0, 1000) > 500, CurLight) { X = r.Next(162, 260) });
                    LightChangedEvent += Ppl.Last().ChangeState;
                }
                Thread.Sleep(1200);
            }
        }

        void Update()
        {
            while(true)
            {
                LightTimer++;
                Thread.Sleep(5);
                if(LightTimer > 500)
                {
                    CurLight = !CurLight;
                    try
                    {
                        LightChangedEvent();
                    }
                    catch (NullReferenceException) { }
                    LightTimer = 0;
                }

                for (int i = 0; i < Cars.Count; i++)
                {
                    if (Cars[i].X < -150 || Cars[i].X > 650)
                        RemoveCar(Cars[i]);
                    CheckForCrash();
                }

                for (int i = 0; i < Ppl.Count; i++)
                    if (Ppl[i].Y < -50 || Ppl[i].Y > 400)
                        RemoveMan(Ppl[i]);
            }
        }

        private void CheckForCrash()
        {
            if (Cars.Count > 1)
                for (int i = 0; i < Cars.Count; i++)
                    for (int j = 0; j < Cars.Count; j++)
                        if ((Math.Abs(Cars[j].X - Cars[i].X)) < 100 && Cars[i] != Cars[j] &&
                            (Cars[j].LeftToRight == Cars[i].LeftToRight ||
                              r.Next(0, 1000) > 997 && Cars[j].LeftToRight != Cars[i].LeftToRight))
                        {
                            Cars[j].CurThread.Abort();
                            Cars[j].IsBrocken = true;
                            LightChangedEvent -= Cars[j].ChangeState;
                            DrawUnit.LocalCS.X = Cars[j].X;
                            Cars.Remove(Cars[i]);
                            HasCrash = true;
                            DrawUnit.LocalCS.onCrash += CleanUp;
                        }

        }

        public void CleanUp()
        {
            DrawUnit.csVisible = true;
            Thread.Sleep(1200);
            Cars.Remove(Cars[0]);
            DrawUnit.LocalCS.onCrash -= CleanUp;
            DrawUnit.csVisible = HasCrash = false;
        }

        void RemoveMan(Man m)
        {
            m.CurThread.Abort();
            LightChangedEvent -= m.ChangeState;
            Ppl.Remove(m);
        }

        void RemoveCar(Car c)
        {
            c.CurThread.Abort();
            LightChangedEvent -= c.ChangeState;
            Cars.Remove(c);
        }

        public void StopSimulation()
        {
            AddThread.Abort();
            UpdThread.Abort();
            foreach(Car c in Cars)
                c.CurThread.Abort();
            foreach (Man m in Ppl)
                m.CurThread.Abort();
        }
    }
}

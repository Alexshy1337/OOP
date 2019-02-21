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
        private int CrashTimer { get; set; } = 0;//счётчик для аварий(чтобы они происходили не слишком часто)
        private int LightTimer { get; set; } = 0;//счётчик для светофора
        public Drawer DrawUnit { get; set; }
        public List<Car> Cars { get; set; }
        public List<Man> Ppl { get; set; }
        private Thread UpdThread { get; set; }
        private Thread AddThread { get; set; }
        public CrashService LocalCrashService { get; set; }
        event Action LightChangedEvent;
        event Action CrashEvent;

        public RoadModel()
        {
            Cars = new List<Car>();
            Ppl = new List<Man>();
            DrawUnit = new Drawer(Cars, Ppl);
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
                if (Cars.Count < 4 && r.Next(0, 1000) > 500 && !HasCrash)
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
                CrashTimer++;
                LightTimer++;
                //if (Ppl.Count > 1)
                //    CheckPplCollisions();
                //if (Cars.Count > 1)
                //    CheckCarCollisions();
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

                //удаление объектов, закончивших своё перемещение по экрану
                for (int i = 0; i < Cars.Count; i++)
                {
                    if (Cars[i].X < -150 || Cars[i].X > 650)
                    {
                        Cars[i].CurThread.Abort();
                        LightChangedEvent -= Cars[i].ChangeState;
                        Cars.Remove(Cars[i]);
                    }
                }
                for (int i = 0; i < Ppl.Count; i++)
                {
                    if (Ppl[i].Y < -50 || Ppl[i].Y > 400)
                    {
                        Ppl[i].CurThread.Abort();
                        LightChangedEvent -= Ppl[i].ChangeState;
                        Ppl.Remove(Ppl[i]);
                    }
                }

            }
        }

        void CheckCarCollisions()
        {
            lock (Cars)
            {
                for (int i = 0; i < Cars.Count - 1; i++)
                {
                    //if (Cars[i].LeftToRight == Cars[i + 1].LeftToRight && (Math.Abs(Cars[i + 1].X - Cars[i].X)) < 135)
                    //{
                    //    if (Cars[i].LeftToRight)
                    //    {
                    //        if (Cars[i].X < Cars[i + 1].X)
                    //        {
                    //            Cars[i].ObstacleX = Cars[i + 1].X;
                    //            Cars[i].CanMove = false;
                    //        }
                    //        else
                    //        {
                    //            Cars[i].ObstacleX = Cars[i + 1].X;
                    //            Cars[i].CanMove = false;
                    //        }
                    //    }
                    //}


                    //if(Cars[i].LeftToRight == Cars[i + 1].LeftToRight)
                    //{
                    //random & 
                    if (((Math.Abs(Cars[i + 1].X - Cars[i].X)) < 100 && Cars[i].LeftToRight != Cars[i + 1].LeftToRight)
                        && CrashTimer > 100 && r.Next(0, 1000) > 900)
                    {
                        Cars[i + 1].CurThread.Abort();
                        LightChangedEvent -= Cars[i + 1].ChangeState;
                        Cars[i + 1].IsBrocken = true;
                        CrashTimer = 0;
                        Cars[i].CurThread.Abort();
                        LightChangedEvent -= Cars[i].ChangeState;
                        Cars.Remove(Cars[i]);
                        HasCrash = true;
                    }
                }

            }
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

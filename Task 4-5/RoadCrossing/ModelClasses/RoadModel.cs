﻿using System;
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
        public bool CurLight { get; set; } = false; //red light
        private int CrashTimer { get; set; } = 0;//счётчик для аварий(чтобы они происходили не слишком часто)
        private int LightTimer { get; set; } = 0;//счётчик для светофора
        public Drawer DrawUnit { get; set; }
        public List<Car> Cars { get; set; }
        public List<Man> Ppl { get; set; }
        private Thread UpdThread { get; set; }
        private Thread AddThread { get; set; }
        event Action GreenLightEvent; //for walkers
        event Action RedLightEvent;//for walkers
        event Action CrashEvent; //car with car only
        
        public RoadModel()
        {
            DrawUnit = new Drawer();
            Cars = new List<Car>();
            Ppl = new List<Man>();
            UpdThread = new Thread(new ThreadStart(Update));
            AddThread = new Thread(new ThreadStart(Additions));
            UpdThread.Start();
            AddThread.Start();
        }

        void Additions()
        {
            while(true)
            {
                if (Cars.Count < 4 && r.Next(0, 1000) > 500)
                    Cars.Add(new Car(r.Next(0, 1000) > 500,!CurLight));
                Thread.Sleep(1000);
                if (Ppl.Count < 4 && r.Next(0, 1000) > 500)
                    Ppl.Add(new Man(r.Next(0, 1000) > 500, CurLight) { X = r.Next(162, 260) });
                Thread.Sleep(1200);
            }
        }

        void Update()
        {
            while(true)
            {
                //CrashTimer++;
                LightTimer++;
                //if (Ppl.Count > 1)
                //    CheckPplCollisions();
                //if (Cars.Count > 1)
                //    CheckCarCollisions();
                Thread.Sleep(5);
                if(LightTimer > 500)
                {
                    CurLight = !CurLight;
                    LightTimer = 0;
                }
                for (int i = 0; i < Cars.Count; i++)
                    if (Cars[i].X < -130 || Cars[i].X > 440)
                    {
                        Cars[i].CurThread.Abort();
                        Cars.Remove(Cars[i]);
                    }
                for (int i = 0; i < Ppl.Count; i++)
                {
                    if (Ppl[i].Y < -40 || Ppl[i].Y > 380)
                    {
                        Ppl[i].CurThread.Abort();
                        Ppl.Remove(Ppl[i]);
                    }
                }

            }
        }

        void ChangeToGreen()
        {
            lock (Cars)
            {
                foreach(Car c in Cars)
                {

                }
            }
        }

        void CheckCarCollisions()
        {
            //checking
            //if( (car1 && car2 are close && moving in different directions)
            //&& crash_clock > needed_value && random.Next(0, 1000) > 900)
            //
            lock(Cars)
            {
                for(int i = 0; i < Cars.Count - 1; i++)
                {
                    if (Cars[i].LeftToRight == Cars[i + 1].LeftToRight && (Math.Abs(Cars[i + 1].X - Cars[i].X)) < 135)
                    {
                        if(Cars[i].LeftToRight)
                        {
                            if (Cars[i].X < Cars[i + 1].X)
                            {
                                Cars[i].ObstacleX = Cars[i + 1].X;
                                Cars[i].CanMove = false;
                            }
                            else
                            {
                                Cars[i].ObstacleX = Cars[i + 1].X;
                                Cars[i].CanMove = false;
                            }
                        }
                    }


                    //if(Cars[i].LeftToRight == Cars[i + 1].LeftToRight)
                    //{
                    //random & 

                }

            }
        }

        void CheckPplCollisions()
        {

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
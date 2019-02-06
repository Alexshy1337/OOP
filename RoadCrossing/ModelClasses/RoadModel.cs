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
        //DateTime startTime { get; set; }
        public Drawer DrawUnit { get; set; }
        public List<Car> Cars { get; set; }
        public List<Man> Ppl { get; set; }
        Thread CurThread { get; set; }


        public RoadModel()//DateTime start)//Size??????????
            //????
        {
            //startTime = start;
            Cars = new List<Car>();
            Ppl = new List<Man>();
        }

        public void Simulation()
        {
            /*
             
            randomAdd ppl, cars
             
             */



        }

    }
}

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class Drawer
    {

        void DrawCar(Graphics g)
        {

        }

        void DrawMan(Graphics g)
        {

        }

        void DrawCrash(Graphics g)
        {

        }

        //MAIN METHOD
        public void DrawFrame(Bitmap bit)
        {
            Graphics g = Graphics.FromImage(bit);



            g.Dispose();
        }






    }
}

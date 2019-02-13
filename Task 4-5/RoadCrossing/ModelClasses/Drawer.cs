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
        void DrawCar(Graphics g, Car car)
        {
            if (car.IsBrocken)
            {
                g.DrawImage(Properties.GraphicsRes.CrashImg, new Rectangle(car.X, 110, 115, 90), new Rectangle(0, 0, 1200, 927), GraphicsUnit.Pixel);
            }
            else if (car.LeftToRight)
            {
                g.DrawImage(Properties.GraphicsRes.CarImg, new Rectangle(car.X, 155, 125, 90), new Rectangle(0, 0, 450, 300), GraphicsUnit.Pixel);
            }
            else
            {
                Image temp = Properties.GraphicsRes.CarImg;
                temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                g.DrawImage(temp, new Rectangle(car.X, 70, 125, 90), new Rectangle(0, 0, 450, 300), GraphicsUnit.Pixel);
                temp.Dispose();
            }
        }

        void DrawMan(Graphics g, Man man)
        {
            if(man.ToptoBottom)
            {
                g.DrawImage(Properties.GraphicsRes.ManImg, new Rectangle(162, man.Y, 25, 30), new Rectangle(0, 0, 46, 61), GraphicsUnit.Pixel);
            }
            else
            {
                Image temp = Properties.GraphicsRes.ManImg;
                temp.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                g.DrawImage(temp, new Rectangle(210, man.Y, 25, 30), new Rectangle(0, 0, 46, 61), GraphicsUnit.Pixel);
                temp.Dispose();
            }
        }

        void DrawCrashService(Graphics g, CrashService cs)
        {
            if (cs.LeftToRight)
            {
                g.DrawImage(Properties.GraphicsRes.CrashServiceImg, new Rectangle(cs.X, 50, 180, 90), new Rectangle(0, 0, 1667, 833), GraphicsUnit.Pixel);
            }
            else
            {
                Image temp = Properties.GraphicsRes.CrashServiceImg;
                temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                g.DrawImage(temp, new Rectangle(cs.X, 130, 180, 90), new Rectangle(0, 0, 1667, 833), GraphicsUnit.Pixel);
                temp.Dispose();
            }

            //if(IsLoaded)

            //DrawCrash

        }

        void DrawLight(Graphics g, bool isGreen)
        {
            if(isGreen)
                g.FillEllipse(Brushes.LightGreen, 285, 39, 18, 18);
            else
                g.FillEllipse(Brushes.Red, 285, 24, 18, 18);
        }

        //MAIN METHOD
        public void DrawFrame(Bitmap bit, List<Car> cars, List<Man> ppl, CrashService crashService = null, bool isGreen = false)
        {
            Graphics g = Graphics.FromImage(bit);

            g.DrawImage(Properties.GraphicsRes.BackgroundImg, new Rectangle(0, 0, bit.Width, bit.Height));
            if(cars != null)
                for (int i = 0; i < cars.Count; i++)
                    DrawCar(g, cars[i]);
            if (ppl != null)
                for (int i = 0; i < ppl.Count; i++)
                    DrawMan(g, ppl[i]);
            if (crashService != null) 
                DrawCrashService(g, crashService);
            DrawLight(g, isGreen);

            g.DrawString("Cars: " + cars.Count.ToString() + " Ppl: " + ppl.Count.ToString(),
                SystemFonts.DefaultFont, Brushes.Black, bit.Width - 100, bit.Height - 30);


            g.Dispose();
        }






    }
}

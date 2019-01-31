using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelClasses;

namespace RoadCrossing
{
    public partial class ModelsForm : Form
    {
        public ModelsForm()
        {
            InitializeComponent();
            models = new List<RoadModel>();
        }

        List<RoadModel> models;
        //RoadModel[] models = new RoadModel[4];

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if(!SB1.Visible)
            {
                e.Graphics.DrawImage(Properties.Resources.BackgroundImg, new Rectangle(0, 0, Panel1.Width, Panel1.Height));

            }




            /*
             
             
                         try
            {
                Bitmap b = new Bitmap(Panel1.Size.Width, Panel1.Size.Height);
                models[0].DrawUnit.DrawFrame(b);
                e.Graphics.DrawImage(b, 0, 0);
                b.Dispose();
            }
            catch (NullReferenceException) { }

             
             */

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (!SB2.Visible)
            {
                e.Graphics.DrawImage(Properties.Resources.BackgroundImg, new Rectangle(0, 0, Panel2.Width, Panel2.Height));

            }

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            if (!SB3.Visible)
            {
                e.Graphics.DrawImage(Properties.Resources.BackgroundImg, new Rectangle(0, 0, Panel3.Width, Panel3.Height));

            }

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {
            if (!SB4.Visible)
            {
                e.Graphics.DrawImage(Properties.Resources.BackgroundImg, new Rectangle(0, 0, Panel4.Width, Panel4.Height));

            }

        }

        private void SB1_Click(object sender, EventArgs e)
        {
            models.Add(new RoadModel());//models[0] = new RoadModel();
            models.Last().DrawUnit = new Drawer();
            Panel1.Invalidate();
            SB1.Visible = false;
        }

        private void SB2_Click(object sender, EventArgs e)
        {
            Panel2.Invalidate();
            SB2.Visible = false;
        }

        private void SB3_Click(object sender, EventArgs e)
        {
            Panel3.Invalidate();
            SB3.Visible = false;
        }

        private void SB4_Click(object sender, EventArgs e)
        {
            Panel4.Invalidate();
            SB4.Visible = false;
        }
    }
}

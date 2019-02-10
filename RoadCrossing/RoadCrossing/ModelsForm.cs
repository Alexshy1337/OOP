﻿using System;
using System.Reflection;
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
            crashServices[0] = new CrashService();
            crashServices[1] = new CrashService();
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty |
            BindingFlags.Instance |
            BindingFlags.NonPublic,
            null,
            Panel1,
            new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty |
            BindingFlags.Instance |
            BindingFlags.NonPublic,
            null,
            Panel2,
            new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty |
            BindingFlags.Instance |
            BindingFlags.NonPublic,
            null,
            Panel3,
            new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty |
            BindingFlags.Instance |
            BindingFlags.NonPublic,
            null,
            Panel4,
            new object[] { true });
            MainTimer.Start();

        }

        RoadModel[] models = new RoadModel[4];
        CrashService[] crashServices = new CrashService[2];

        private void SB1_Click(object sender, EventArgs e)
        {
            crashServices[0] = new CrashService();
            SB1.Visible = false;
            models[0] = new RoadModel(DateTime.Now);
            Panel1.Invalidate();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if(!SB1.Visible)
            {
                Bitmap b = new Bitmap(Panel1.Size.Width, Panel1.Size.Height);
                models[0].DrawUnit.DrawFrame(b, models[0].Cars, models[0].Ppl, crashServices[0]);
                e.Graphics.DrawImage(b, 0, 0);
                b.Dispose();
            }
        }

        private void SB2_Click(object sender, EventArgs e)
        {
            SB2.Visible = false;
            Panel2.Invalidate();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (!SB2.Visible)
            {
                Bitmap b = new Bitmap(Panel2.Size.Width, Panel2.Size.Height);
                models[1].DrawUnit.DrawFrame(b, models[1].Cars, models[1].Ppl, crashServices[0]);
                e.Graphics.DrawImage(b, 0, 0);
                b.Dispose();
            }

        }

        private void SB3_Click(object sender, EventArgs e)
        {
            SB3.Visible = false;
            Panel3.Invalidate();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            if (!SB3.Visible)
            {
                Bitmap b = new Bitmap(Panel3.Size.Width, Panel3.Size.Height);
                models[2].DrawUnit.DrawFrame(b, models[2].Cars, models[2].Ppl, crashServices[0]);
                e.Graphics.DrawImage(b, 0, 0);
                b.Dispose();
            }

        }

        private void SB4_Click(object sender, EventArgs e)
        {
            SB4.Visible = false;
            Panel4.Invalidate();
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {
            if (!SB4.Visible)
            {
                Bitmap b = new Bitmap(Panel4.Size.Width, Panel4.Size.Height);
                models[3].DrawUnit.DrawFrame(b, models[3].Cars, models[3].Ppl, crashServices[0]);
                e.Graphics.DrawImage(b, 0, 0);
                b.Dispose();
            }

        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            Panel1.Invalidate();
            Panel2.Invalidate();
            Panel3.Invalidate();
            Panel4.Invalidate();
        }
    }
}

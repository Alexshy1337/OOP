﻿using System;
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
        }

        List<RoadModel> models;
        //RoadModel[] models = new RoadModel[4];

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Panel1.Size.Width, Panel1.Size.Height);
            models[0].DrawUnit.DrawFrame(b);
            //RoadModel.DrawFrame();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SB1_Click(object sender, EventArgs e)
        {
            //models.Add(new RoadModel());
            //models[0] = new RoadModel();
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
            Panel3.Invalidate();
            SB3.Visible = false;
        }
    }
}

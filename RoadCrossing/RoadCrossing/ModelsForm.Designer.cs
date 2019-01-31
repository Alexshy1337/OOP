namespace RoadCrossing
{
    partial class ModelsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.SB1 = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.SB2 = new System.Windows.Forms.Button();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.SB3 = new System.Windows.Forms.Button();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.SB4 = new System.Windows.Forms.Button();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1212, 692);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.SB1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(600, 340);
            this.Panel1.TabIndex = 0;
            this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // SB1
            // 
            this.SB1.Location = new System.Drawing.Point(262, 170);
            this.SB1.Name = "SB1";
            this.SB1.Size = new System.Drawing.Size(75, 23);
            this.SB1.TabIndex = 0;
            this.SB1.Text = "Start";
            this.SB1.UseVisualStyleBackColor = true;
            this.SB1.Click += new System.EventHandler(this.SB1_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.SB2);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(609, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(600, 340);
            this.Panel2.TabIndex = 1;
            this.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // SB2
            // 
            this.SB2.Location = new System.Drawing.Point(262, 170);
            this.SB2.Name = "SB2";
            this.SB2.Size = new System.Drawing.Size(75, 23);
            this.SB2.TabIndex = 0;
            this.SB2.Text = "Start";
            this.SB2.UseVisualStyleBackColor = true;
            this.SB2.Click += new System.EventHandler(this.SB2_Click);
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.SB3);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(3, 349);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(600, 340);
            this.Panel3.TabIndex = 2;
            this.Panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // SB3
            // 
            this.SB3.Location = new System.Drawing.Point(262, 170);
            this.SB3.Name = "SB3";
            this.SB3.Size = new System.Drawing.Size(75, 23);
            this.SB3.TabIndex = 0;
            this.SB3.Text = "Start";
            this.SB3.UseVisualStyleBackColor = true;
            this.SB3.Click += new System.EventHandler(this.SB3_Click);
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.SB4);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(609, 349);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(600, 340);
            this.Panel4.TabIndex = 3;
            this.Panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel4_Paint);
            // 
            // SB4
            // 
            this.SB4.Location = new System.Drawing.Point(262, 170);
            this.SB4.Name = "SB4";
            this.SB4.Size = new System.Drawing.Size(75, 23);
            this.SB4.TabIndex = 0;
            this.SB4.Text = "Start";
            this.SB4.UseVisualStyleBackColor = true;
            this.SB4.Click += new System.EventHandler(this.SB4_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 40;
            // 
            // ModelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModelsForm";
            this.Text = "Road Crossing";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.Panel Panel4;
        private System.Windows.Forms.Button SB1;
        private System.Windows.Forms.Button SB2;
        private System.Windows.Forms.Button SB3;
        private System.Windows.Forms.Button SB4;
        private System.Windows.Forms.Timer MainTimer;
    }
}


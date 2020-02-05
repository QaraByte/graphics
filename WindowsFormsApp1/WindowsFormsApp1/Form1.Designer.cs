namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnWindows = new System.Windows.Forms.Button();
            this.cbColors = new System.Windows.Forms.ComboBox();
            this.timerWindows = new System.Windows.Forms.Timer(this.components);
            this.btnMoon = new System.Windows.Forms.Button();
            this.timerSky = new System.Windows.Forms.Timer(this.components);
            this.buttonSky = new System.Windows.Forms.Button();
            this.btnStars = new System.Windows.Forms.Button();
            this.timerStars = new System.Windows.Forms.Timer(this.components);
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.lblColorWindows = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Рисовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(674, 330);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(916, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.White;
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfo.Location = new System.Drawing.Point(680, 0);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(227, 330);
            this.txtInfo.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(145, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 39);
            this.button2.TabIndex = 4;
            this.button2.Text = "Закрасить дома";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(547, 336);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(127, 39);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnWindows
            // 
            this.btnWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindows.Location = new System.Drawing.Point(247, 336);
            this.btnWindows.Name = "btnWindows";
            this.btnWindows.Size = new System.Drawing.Size(90, 39);
            this.btnWindows.TabIndex = 6;
            this.btnWindows.Text = "Нарисовать окна";
            this.btnWindows.UseVisualStyleBackColor = true;
            this.btnWindows.Visible = false;
            this.btnWindows.Click += new System.EventHandler(this.btnWindows_Click);
            // 
            // cbColors
            // 
            this.cbColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColors.FormattingEnabled = true;
            this.cbColors.Items.AddRange(new object[] {
            "Желтый",
            "Красный",
            "Зеленый",
            "Черный",
            "Белый",
            "Фиолетовый",
            "Розовый"});
            this.cbColors.Location = new System.Drawing.Point(420, 354);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(121, 21);
            this.cbColors.TabIndex = 7;
            // 
            // timerWindows
            // 
            this.timerWindows.Interval = 200;
            this.timerWindows.Tick += new System.EventHandler(this.timerWindows_Tick);
            // 
            // btnMoon
            // 
            this.btnMoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoon.Location = new System.Drawing.Point(680, 336);
            this.btnMoon.Name = "btnMoon";
            this.btnMoon.Size = new System.Drawing.Size(79, 39);
            this.btnMoon.TabIndex = 8;
            this.btnMoon.Text = "Moon";
            this.btnMoon.UseVisualStyleBackColor = true;
            this.btnMoon.Click += new System.EventHandler(this.btnMoon_Click);
            // 
            // timerSky
            // 
            this.timerSky.Interval = 200;
            this.timerSky.Tick += new System.EventHandler(this.timerSky_Tick);
            // 
            // buttonSky
            // 
            this.buttonSky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSky.Location = new System.Drawing.Point(765, 336);
            this.buttonSky.Name = "buttonSky";
            this.buttonSky.Size = new System.Drawing.Size(77, 39);
            this.buttonSky.TabIndex = 9;
            this.buttonSky.Text = "Ночное небо";
            this.buttonSky.UseVisualStyleBackColor = true;
            this.buttonSky.Click += new System.EventHandler(this.buttonSky_Click);
            // 
            // btnStars
            // 
            this.btnStars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStars.Location = new System.Drawing.Point(848, 336);
            this.btnStars.Name = "btnStars";
            this.btnStars.Size = new System.Drawing.Size(56, 39);
            this.btnStars.TabIndex = 10;
            this.btnStars.Text = "Звезды";
            this.btnStars.UseVisualStyleBackColor = true;
            this.btnStars.Click += new System.EventHandler(this.btnStars_Click);
            // 
            // timerStars
            // 
            this.timerStars.Interval = 500;
            this.timerStars.Tick += new System.EventHandler(this.timerStars_Tick);
            // 
            // timerStart
            // 
            this.timerStart.Enabled = true;
            this.timerStart.Interval = 1000;
            this.timerStart.Tick += new System.EventHandler(this.timerStart_Tick);
            // 
            // lblColorWindows
            // 
            this.lblColorWindows.AutoSize = true;
            this.lblColorWindows.Location = new System.Drawing.Point(417, 338);
            this.lblColorWindows.Name = "lblColorWindows";
            this.lblColorWindows.Size = new System.Drawing.Size(62, 13);
            this.lblColorWindows.TabIndex = 11;
            this.lblColorWindows.Text = "Цвет окон:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 408);
            this.Controls.Add(this.lblColorWindows);
            this.Controls.Add(this.btnStars);
            this.Controls.Add(this.buttonSky);
            this.Controls.Add(this.btnMoon);
            this.Controls.Add(this.cbColors);
            this.Controls.Add(this.btnWindows);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Атака НЛО";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnWindows;
        private System.Windows.Forms.ComboBox cbColors;
        private System.Windows.Forms.Timer timerWindows;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnMoon;
        private System.Windows.Forms.Timer timerSky;
        private System.Windows.Forms.Button buttonSky;
        private System.Windows.Forms.Button btnStars;
        private System.Windows.Forms.Timer timerStars;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.Label lblColorWindows;
    }
}


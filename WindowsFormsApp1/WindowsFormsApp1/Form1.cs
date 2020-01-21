using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //DrawLineInt(100, 100, 300, 150);
            //DrawLineInt(300, 150, 200, 350);
            button1.Enabled = false;
        }

        Pen p = new Pen(Color.Blue);
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        Random rnd = new Random();

        public void DrawLineInt(int c)
        {
            switch (c)
            {
                case 1: x1 = 1; y1 = 300; x2 = rnd.Next(30, 50); y2 = 300; break;           // ->>
                case 2: x1 = x2; y1 = y2; x2 = x1; y2 = rnd.Next(200, 300); break;          // /\
                case 3: x1 = x2; y1 = y2; x2 = x1 + rnd.Next(x1 + 20, x1 + 50); break;      // ->>
                case 4: x1 = x2; y1 = y2; x2 = x1; y2 = 300; break;                         // \/
                case 5: x1 = x2; y1 = y2; x2 = rnd.Next(x1, x1 + 20); y2 = 300; break;      // ->>
                case 6: x1 = x2; y1 = y2; x2 = x1; y2 = rnd.Next(200, 300); break;          // /\
                case 7: x1 = x2; y1 = y2; x2 = rnd.Next(x1 + 20, x1 + 50); y2 = y1; break;  // ->>
                case 8: x1 = x2; y1 = y2; x2 = x1; y2 = 300; break;                         // \/
                case 9: x1 = x2; y1 = y2; x2 = rnd.Next(x1, x1 + 20); y2 = 300; break;      // ->>
                case 10: x1 = x2; y1 = y2; x2 = x1; y2 = rnd.Next(200, 300); break;         // /\
                case 11: x1 = x2; y1 = y2; x2 = rnd.Next(x1+20, x1 + 50); y2 = y1; break;   // ->>
                case 12: x1 = x2; y1 = y2; x2 = x1; y2 = 300; break;                        // \/
            }

            g.DrawLine(p, x1, y1, x2, y2);
            pictureBox1.Image = b;
            
            statusLabel1.Text = "Координаты: x1=" + x1 + "; y1=" + y1 + "; x2=" + x2 + "; y2=" + y2;
            txtInfo.Text += "Шаг: " + c1 + Environment.NewLine;
            txtInfo.Text += "Координаты: x1=" + x1 + "; y1=" + y1 + "; x2=" + x2 + "; y2=" + y2 + Environment.NewLine;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        int c1 = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawLineInt(c1);

            c1++;

            if (c1 > 11)
            {
                c1 = 1;
                button1.Enabled = true;
                timer1.Enabled = false;
                return;
            }
                
            timer1.Enabled = false;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DrawLineInt(c1);
            c1++;
            timer1.Enabled = true;
            timer2.Enabled = false;
        }
    }
}

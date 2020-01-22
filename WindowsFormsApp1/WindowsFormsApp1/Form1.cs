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
            button1.Enabled = false;
        }

        Pen p = new Pen(Color.Blue);
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        Random rnd = new Random();
        const int UNDERGROUND= 300;
        int steps = 20;
        string direction = "right";
        const string RIGHT = "right";
        const string LEFT = "left";
        const string UP = "up";
        const string DOWN = "down";
        string dir = RIGHT;
        const int BETWEEN = 10;

        public void DrawLineCity(int c)
        {
            switch (c)
            {
                case 1: direction = RIGHT; break;
                case 2: direction = UP; break;
                case 3: direction = RIGHT; break;
                case 4: direction = DOWN; break;
                case 5: direction = RIGHT; break;
                case 6: direction = UP; break;
                case 7: direction = RIGHT; break;
                case 8: direction = DOWN; break;
                case 9: direction = RIGHT; break;
                case 10: direction = UP; break;
                case 11: direction = RIGHT; break;
                case 12: direction = DOWN; break;
                case 13: direction = RIGHT; break;
                case 14: direction = UP; break;
                case 15: direction = RIGHT; break;
                case 16: direction = DOWN; break;
                case 17: direction = RIGHT; break;
                case 18: direction = UP; break;
                case 19: direction = RIGHT; break;
                case 20: direction = DOWN; break;
            }

            if (direction == RIGHT)
            {
                if (x1 == 0)
                {
                    x1 = 1; y1 = UNDERGROUND; x2 = 15; y2 = UNDERGROUND;
                }
                else
                {
                    if (dir == UP)
                    {
                        x1 = x2; y1 = y2; x2 = x1 + rnd.Next(40, 70);
                        dir = RIGHT;
                    }
                    else
                    {
                        x1 = x2; y1 = y2; x2 = x1 + BETWEEN;
                    }
                }
            }
            else if (direction == LEFT)
            {

            }
            else if (direction == UP)
            {
                x1 = x2; y1 = y2; x2 = x1; y2 = rnd.Next(180, 280);
                dir = UP;
            }
            else
            {
                x1 = x2; y1 = y2; x2 = x1; y2 = UNDERGROUND;
            }

            g.DrawLine(p, x1, y1, x2, y2);
            pictureBox1.Image = b;

            statusLabel1.Text = "Координаты: x1=" + x1 + "; y1=" + y1 + "; x2=" + x2 + "; y2=" + y2;
            txtInfo.Text += "Шаг: " + c1 + ". " + direction + Environment.NewLine;
            txtInfo.Text += "Координаты: x1=" + x1 + "; y1=" + y1 + "; x2=" + x2 + "; y2=" + y2 + Environment.NewLine;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        int c1 = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawLineCity(c1);

            c1++;

            if (c1 > steps)
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
            DrawLineCity(c1);
            c1++;
            timer1.Enabled = true;
            timer2.Enabled = false;
        }
    }
}

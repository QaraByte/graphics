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
        //Image image;
        //Rectangle rect;

        public Form1()
        {
            InitializeComponent();
            //image = Properties.Resources.hyundai_elantra;
            //rect = new Rectangle(20, 20, 70, 70);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            p = new Pen(Color.Blue);
            txtInfo.Text += "Ширина холста: " + b.Width + Environment.NewLine;
            timer1.Enabled = true;
            button1.Enabled = false;
        }

        Pen p;
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        Random rnd = new Random();
        const int UNDERGROUND= 300;
        /// <summary>
        /// Количество шагов
        /// </summary>
        int steps = 21;
        string direction = "right";
        const string RIGHT = "right";
        const string LEFT = "left";
        const string UP = "up";
        const string DOWN = "down";
        string dir = RIGHT;
        const int BETWEEN = 10;
        int houses = 1;

        public void DrawLineCity(int c)
        {
            if (c % 2 != 0)
                direction = RIGHT;
            else if (c == 2 || FuncUP(c))
                direction = UP;
            else if (c % 4 == 0)
                direction = DOWN;

            if (direction == RIGHT)
            {
                if (x1 == 0)
                {
                    x1 = 1; y1 = UNDERGROUND; x2 = 20; y2 = UNDERGROUND;
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
                        //Если ширина Bitmap рядом, то проводим линию до конца
                        if (x2 > b.Width - 90 && houses >= 9)
                        {
                            x2 = x1 + 100;
                            timer1.Enabled = false;
                            timer2.Enabled = false;
                            button1.Enabled = true;
                        }
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
                houses += 1;
                txtInfo.Text += "Количество домов: " + houses + Environment.NewLine;
            }

            g.DrawLine(p, x1, y1, x2, y2);
            pictureBox1.Image = b;

            statusLabel1.Text = "Координаты: x1=" + x1 + "; y1=" + y1 + "; x2=" + x2 + "; y2=" + y2;
            txtInfo.Text += "Шаг: " + c + ". " + direction + Environment.NewLine;
            txtInfo.Text += "Координаты: x1=" + x1 + "; y1=" + y1 + "; x2=" + x2 + "; y2=" + y2 + Environment.NewLine;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //g = e.Graphics;
            //g.DrawImage(image, rect);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < steps; i++)
            {
                DrawLineCity(i);
            }

            //c1++;

            //if (i >= steps - 1)
            //{
            //    c1 = 1;
            //    button1.Enabled = true;
            //    timer1.Enabled = false;
            //    return;
            //}

            timer1.Enabled = false;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < steps; i++)
            {
                DrawLineCity(i);
            }
            //c1++;
            //timer1.Enabled = true;
            button1.Enabled = true;
            timer2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        public bool FuncUP(int c)
        {
            double i = Math.Ceiling(Convert.ToDouble(c / 4));
            for (int j = 0; j < i; j++)
            {
                c = c - 4;
                if (c - 2 == 0)
                    return true;
            }
            return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
            txtInfo.Text = "";
        }
    }
}

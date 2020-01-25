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
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInfo.Text += "Ширина холста: " + b.Width + Environment.NewLine;
            timer1.Enabled = true;
            button1.Enabled = false;
        }

        Random rnd = new Random();
        
        const string RIGHT = "right";
        const string LEFT = "left";
        const string UP = "up";
        const string DOWN = "down";
        /// <summary>
        /// Количество шагов
        /// </summary>
        int steps = 21;
        const int BETWEEN = 10;
        int houses = 0;
        CoreDraw outlinecity = new CoreDraw(Color.Blue, 1);

        public void DrawLineCity(int c)
        {
            if (c % 2 != 0)
                outlinecity.direction = RIGHT;
            else if (c == 2 || FuncUP(c))
                outlinecity.direction = UP;
            else if (c % 4 == 0)
                outlinecity.direction = DOWN;

            if (outlinecity.direction == RIGHT)
            {
                if (outlinecity.x1 == 0)
                {
                    outlinecity.x1 = 1;
                    outlinecity.y1 = outlinecity.UNDERGROUND;
                    outlinecity.x2 = 20;
                    outlinecity.y2 = outlinecity.UNDERGROUND;
                }
                else
                {
                    if (outlinecity.pastDir == UP)
                    {
                        outlinecity.x1 = outlinecity.x2;
                        outlinecity.y1 = outlinecity.y2;
                        outlinecity.x2 = outlinecity.x1 + rnd.Next(40, 70);
                        outlinecity.pastDir = RIGHT;
                    }
                    else
                    {
                        outlinecity.x1 = outlinecity.x2;
                        outlinecity.y1 = outlinecity.y2;
                        outlinecity.x2 = outlinecity.x1 + BETWEEN;
                        outlinecity.pastDir = RIGHT;
                        //Если ширина Bitmap рядом, то проводим линию до конца
                        if (outlinecity.x2 > b.Width - 90 && houses >= 9)
                        {
                            outlinecity.x2 = outlinecity.x1 + 100;
                            timer1.Enabled = false;
                            timer2.Enabled = false;
                            button1.Enabled = true;
                        }
                    }
                }
            }
            else if (outlinecity.direction == LEFT)
            {

            }
            else if (outlinecity.direction == UP)
            {
                outlinecity.x1 = outlinecity.x2;
                outlinecity.y1 = outlinecity.y2;
                outlinecity.x2 = outlinecity.x1;
                outlinecity.y2 = rnd.Next(180, 280);
                outlinecity.pastDir = UP;
            }
            else //Направление вниз
            {
                outlinecity.x1 = outlinecity.x2;
                outlinecity.y1 = outlinecity.y2;
                outlinecity.x2 = outlinecity.x1;
                outlinecity.y2 = outlinecity.UNDERGROUND;
                houses += 1;
                outlinecity.pastDir = DOWN;
                txtInfo.Text += "Количество домов: " + houses + Environment.NewLine;
            }

            g.DrawLine(outlinecity.pen, outlinecity.x1, outlinecity.y1, outlinecity.x2, outlinecity.y2);
            pictureBox1.Image = b;

            statusLabel1.Text = "Координаты: x1=" + outlinecity.x1 + "; y1=" + outlinecity.y1 + "; x2=" + outlinecity.x2 + "; y2=" + outlinecity.y2;
            txtInfo.Text += "Шаг: " + c + ". " + outlinecity.direction + Environment.NewLine;
            txtInfo.Text += "Координаты: x1=" + outlinecity.x1 + "; y1=" + outlinecity.y1 + "; x2=" + outlinecity.x2 + "; y2=" + outlinecity.y2 + Environment.NewLine;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //g = e.Graphics;
            //g.DrawImage(image, rect);
        }

        int c = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawLineCity(c);
            c++;

            if (c == steps)
                timer1.Enabled = false;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < steps; i++)
            {
                DrawLineCity(i);
            }
            
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
            outlinecity = new CoreDraw(Color.Orange, 1);
            houses = 0;
        }
    }
}

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

        //Image image;
        //Rectangle rect;

        public Form1()
        {
            InitializeComponent();
            //image = Properties.Resources.hyundai_elantra;
            //rect = new Rectangle(20, 20, 70, 70);
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        CoreDrawCity outlinecity;
        PaintArea city;

        private void button1_Click(object sender, EventArgs e)
        {
            outlinecity = new CoreDrawCity(Color.FromArgb(55, 82, 99), 1);
            outlinecity.g = Graphics.FromImage(b);
            txtInfo.Text += "Ширина холста: " + b.Width + Environment.NewLine;
            timer1.Enabled = true;
            button1.Enabled = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //g = e.Graphics;
            //g.DrawImage(image, rect);
        }

        int c = 1;
        /// <summary>
        /// Предыдущее направление
        /// </summary>
        string pastDir;
        bool end = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            end = outlinecity.DrawLineCity(c, pastDir, b.Width);
            pictureBox1.Image = b;

            if (end)
            {
                pictureBox1.Image = b;
                timer1.Enabled = false;
                timer2.Enabled = true;
                button1.Enabled = true;
            }

            pastDir = outlinecity.direction;

            if (outlinecity.direction == "down")
            {
                txtInfo.Text += "Шаг: " + c + ". " + outlinecity.direction + Environment.NewLine;
                txtInfo.Text += "Координаты: x=[" + outlinecity.coords.x1 + ";" + outlinecity.coords.y1 + "]; y=[" + outlinecity.coords.x2 + ";" + outlinecity.coords.y2 + "]" + Environment.NewLine;
                txtInfo.Text += "Количество домов: " + outlinecity.houses + Environment.NewLine;
            }
            else
            {
                statusLabel1.Text = "Координаты: x=[" + outlinecity.coords.x1 + ";" + outlinecity.coords.y1 + "]; y=[" + outlinecity.coords.x2 + ";" + outlinecity.coords.y2 + "]";
                txtInfo.Text += "Шаг: " + c + ". " + outlinecity.direction + Environment.NewLine;
                txtInfo.Text += "Координаты: x=[" + outlinecity.coords.x1 + ";" + outlinecity.coords.y1 + "]; y=[" + outlinecity.coords.x2 + ";" + outlinecity.coords.y2 + "]" + Environment.NewLine;
            }

            c++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button2_Click(button2, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            city = new PaintArea();
            city.g = Graphics.FromImage(b);
            
            if (outlinecity != null)
            {
                //Выбираем, чтобы X и Y не были равны нулю
                Point[] points2 = outlinecity.points.Where(t => t.X != 0 || t.Y != 0).ToArray();
                if (points2.Length > 0)
                {
                    points2 = city.PaintCity(points2, b.Width, b.Height);
                    //Закрашивание полигона
                    city.g.FillPolygon(city.brush, points2);
                    pictureBox1.Image = b;
                    //Вывод координат
                    for (int i = 0; i < points2.Length; i++)
                        txtInfo.Text += "Координаты: [" + points2[i].X + ";" + points2[i].Y + "]" + Environment.NewLine;

                    txtInfo.Text += city.pen.Color.ToString() + Environment.NewLine;
                    timerWindows.Enabled = true;
                    timer2.Enabled = false;
                }
                else
                    txtInfo.Text += "Нет полигона для заливки." + Environment.NewLine;
            }
            else
                txtInfo.Text += "Сначала нарисуйте контуры города." + Environment.NewLine;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            c = 1;
            outlinecity.g.Clear(Color.White);
            pictureBox1.Refresh();
            txtInfo.Text = "";
        }

        private void btnWindows_Click(object sender, EventArgs e)
        {
            Point[] points2 = outlinecity.points.Where(t => t.X != 0 || t.Y != 0).ToArray();
            string color = cbColors.Text;
            if (points2.Length > 0)
            {
                int position = 0;
                for (int i = 1; i < outlinecity.houses + 1; i++)
                {
                    position = city.DrawWindows(points2, position, color);
                    if (position < points2.Length)
                        pictureBox1.Image = b;
                }
                //txtInfo.Text += "Координаты окон дома " + i + ":" + Environment.NewLine;
                for (int j = 0; j < city.windowsPoints.Count; j++)
                {
                    txtInfo.Text += city.windowsPoints[j] + Environment.NewLine;
                }
            }
        }

        private void timerWindows_Tick(object sender, EventArgs e)
        {
            btnWindows_Click(btnWindows, new EventArgs());
            timerWindows.Enabled = false;
        }

        private void btnMoon_Click(object sender, EventArgs e)
        {
            Moon moon = new Moon();
            moon.g = Graphics.FromImage(b);
            moon.DrawMoon();
            pictureBox1.Image = b;
            txtInfo.Text += "Координаты луны:" + Environment.NewLine;
            txtInfo.Text += "x=" + moon.point[0].X + ";y=" + moon.point[0].Y;
        }

        private void buttonSky_Click(object sender, EventArgs e)
        {
            if (outlinecity.points != null)
            {
                //Выбираем, чтобы X и Y не были равны нулю
                Point[] points2 = outlinecity.points.Where(t => t.IsEmpty == false).ToArray();
                Point[] points = new Point[points2.Length + 2];
                for (int i = 0; i < points2.Length; i++)
                {
                    points[i] = points2[i];
                    if (i == points2.Length - 1)
                    {
                        points[i + 1].X = b.Width;
                        points[i + 1].Y = 0;
                        points[i + 2].X = 0;
                        points[i + 2].Y = 0;
                    }
                }
                Sky sky = new Sky();
                sky.g = Graphics.FromImage(b);
                sky.PaintSky(points);
                pictureBox1.Image = b;
            }
        }
    }
}

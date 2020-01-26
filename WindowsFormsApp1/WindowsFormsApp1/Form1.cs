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
        PaintArea paintCity;

        private void button1_Click(object sender, EventArgs e)
        {
            outlinecity = new CoreDrawCity(Color.Blue, 1);
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

            //Если ширина Bitmap рядом, то проводим линию до конца
            if (end)
            {
                pictureBox1.Image = b;
                timer1.Enabled = false;
                timer2.Enabled = false;
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            paintCity = new PaintArea();
            paintCity.g = Graphics.FromImage(b);
            Brush brush = new SolidBrush(Color.DarkBlue);
            colorDialog1.FullOpen = true; ;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                brush = new SolidBrush(colorDialog1.Color);
            }
            Pen pen = new Pen(brush);
            
            if (outlinecity != null)
            {
                //Выбираем, чтобы X и Y не равны нулю
                Point[] points2 = outlinecity.points.Where(t => t.X != 0 || t.Y != 0).ToArray();
                if (points2.Length > 0)
                {
                    Point[] points = new Point[points2.Length + 2];
                    for (int j = 0; j < points2.Length; j++)
                    {
                        points[j] = points2[j];
                    }

                    //Заполняем две крайние точки, которые равны ширине и высоте Bitmap
                    points[points.Length - 2].X = b.Width;
                    points[points.Length - 2].Y = b.Height;
                    points[points.Length - 1].X = 0;
                    points[points.Length - 1].Y = b.Height;
                    //Закрашивание полигона
                    paintCity.g.FillPolygon(brush, points);
                    pictureBox1.Image = b;
                    //Вывод координат
                    for (int i = 0; i < points.Length; i++)
                        txtInfo.Text += "Координаты: [" + points[i].X + ";" + points[i].Y + "]" + Environment.NewLine;

                    txtInfo.Text += pen.Color.ToString() + Environment.NewLine;
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
    }
}

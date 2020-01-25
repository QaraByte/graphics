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

        /// <summary>
        /// Количество шагов
        /// </summary>
        int steps = 21;
        
        CoreDrawCity outlinecity = new CoreDrawCity(Color.Blue, 1);

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //g = e.Graphics;
            //g.DrawImage(image, rect);
        }

        int c = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            outlinecity.DrawLineCity(c);

            g.DrawLine(outlinecity.pen, outlinecity.coords.x1, outlinecity.coords.y1, outlinecity.coords.x2, outlinecity.coords.y2);
            pictureBox1.Image = b;
            if (outlinecity.direction == "down")
                txtInfo.Text += "Количество домов: " + outlinecity.houses + Environment.NewLine;
            //Если ширина Bitmap рядом, то проводим линию до конца
            if (outlinecity.coords.x2 > b.Width - 90 && outlinecity.houses >= 9)
            {
                outlinecity.coords.x2 = outlinecity.coords.x1 + 100;
                timer1.Enabled = false;
                timer2.Enabled = false;
                button1.Enabled = true;
            }

            statusLabel1.Text = "Координаты: x1=" + outlinecity.coords.x1 + "; y1=" + outlinecity.coords.y1 + "; x2=" + outlinecity.coords.x2 + "; y2=" + outlinecity.coords.y2;
            txtInfo.Text += "Шаг: " + c + ". " + outlinecity.direction + Environment.NewLine;
            txtInfo.Text += "Координаты: x1=" + outlinecity.coords.x1 + "; y1=" + outlinecity.coords.y1 + "; x2=" + outlinecity.coords.x2 + "; y2=" + outlinecity.coords.y2 + Environment.NewLine;

            c++;

            if (c == steps)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < steps; i++)
            {
                outlinecity.DrawLineCity(i);
            }

            g.DrawLine(outlinecity.pen, outlinecity.coords.x1, outlinecity.coords.y1, outlinecity.coords.x2, outlinecity.coords.y2);
            pictureBox1.Image = b;
            if (outlinecity.direction == "down")
                txtInfo.Text += "Количество домов: " + outlinecity.houses + Environment.NewLine;
            //Если ширина Bitmap рядом, то проводим линию до конца
            if (outlinecity.coords.x2 > b.Width - 90 && outlinecity.houses >= 9)
            {
                outlinecity.coords.x2 = outlinecity.coords.x1 + 100;
                timer1.Enabled = false;
                timer2.Enabled = false;
                button1.Enabled = true;
            }

            statusLabel1.Text = "Координаты: x1=" + outlinecity.coords.x1 + "; y1=" + outlinecity.coords.y1 + "; x2=" + outlinecity.coords.x2 + "; y2=" + outlinecity.coords.y2;
            txtInfo.Text += "Шаг: " + c + ". " + outlinecity.direction + Environment.NewLine;
            txtInfo.Text += "Координаты: x1=" + outlinecity.coords.x1 + "; y1=" + outlinecity.coords.y1 + "; x2=" + outlinecity.coords.x2 + "; y2=" + outlinecity.coords.y2 + Environment.NewLine;

            c++;

            if (c == steps)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
            txtInfo.Text = "";
            outlinecity = new CoreDrawCity(Color.Orange, 1);
        }
    }
}

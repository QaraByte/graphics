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
    public partial class About : Form
    {
        Bitmap b;
        Graphics g;

        public About()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            Pen pen = new Pen(Color.FromArgb(47, 79, 79));
            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            g.DrawRectangle(pen, rect);
            Brush brush = new SolidBrush(Color.FromArgb(47, 79, 79));
            g.FillRectangle(brush, rect);
            brush = new SolidBrush(Color.White);
            int y = 10;
            Font fontName = new Font("Arial", 16);
            g.DrawString("Игра \"Атака НЛО\"", fontName, brush, 10, y);
            Font fontDeveloper = new Font("Arial", 12);
            g.DrawString("Автор: Бексатов Нурбек,", fontDeveloper, brush, 10, y + 45);
            Font fontEmail = new Font("Arial", 12);
            g.DrawString("e-mail: pchelpkz16@gmail.com", fontEmail, brush, 10, y + 65);
            Font fontCopy = new Font("Arial", 12);
            g.DrawString("© Almaty, 2020", fontCopy, brush, 10, y + 85);
            g = Graphics.FromImage(b);
            pictureBox1.Image = b;
        }

        private void About_KeyPress(object sender, KeyPressEventArgs e)
        {
            //About about = new About();
            //about.Close();
        }

        private void About_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void About_Shown(object sender, EventArgs e)
        {
            
        }
    }
}

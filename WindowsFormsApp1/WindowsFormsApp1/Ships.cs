using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Ships
    {
        public Image image;
        public Rectangle rect;
        public int c=0;

        public Ships(int x, int y)
        {
            image = Properties.Resources.spaceship001;
            rect = new Rectangle(x, y, 50, 30);
        }
    }
}

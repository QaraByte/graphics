using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CoreDraw
    {
        public string direction = "right";
        /// <summary>
        /// Нижний предел
        /// </summary>
        public readonly int UNDERGROUND;
        /// <summary>
        /// Координаты
        /// </summary>
        public int x1, y1, x2, y2;
        /// <summary>
        /// Предыдущее направление
        /// </summary>
        public string pastDir;
        public Pen pen;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="color">Цвет карандаша</param>
        /// <param name="w">Ширина карандаша</param>
        public CoreDraw(Color color, int w)
        {
            pen = new Pen(color);
            pen.Width = w;
            UNDERGROUND = 300;
            x1 = 0;
            y1 = 0;
            x2 = 0;
            y2 = 0;
        }
    }
}

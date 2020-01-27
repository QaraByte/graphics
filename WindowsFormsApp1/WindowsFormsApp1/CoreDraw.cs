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
        public Pen pen;
        public Graphics g;
    }

    public class CoreDrawCity:CoreDraw
    {
        public class Directions
        {
            public string RIGHT;
            public readonly string LEFT = "left";
            public readonly string UP = "up";
            public readonly string DOWN = "down";
        }
        /// <summary>
        /// Координаты
        /// </summary>
        public class Coords
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
            public Coords()
            {
                x1 = 0;
                y1 = 0;
                x2 = 0;
                y2 = 0;
            }
        }

        public string direction = "right";
        public int BETWEEN = 12;
        public int houses = 0;
        Random rnd = new Random();
        public Coords coords;
        Directions directions = new Directions();
        /// <summary>
        /// Нижний предел
        /// </summary>
        public int UNDERGROUND;
        public Point[] points = new Point[100];

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="color">Цвет карандаша</param>
        /// <param name="w">Ширина карандаша</param>
        public CoreDrawCity(Color color, int w)
        {
            pen = new Pen(color);
            pen.Width = w;
            UNDERGROUND = 300;
            directions.RIGHT = "right";
            coords = new Coords();
        }

        public bool DrawLineCity(int c, string dir, int w)
        {
            if (c % 2 != 0)
                direction = directions.RIGHT;
            else if (c == 2 || Funcs.FuncUP(c))
                direction = directions.UP;
            else if (c % 4 == 0)
                direction = directions.DOWN;

            if (direction == directions.RIGHT)
            {
                if (coords.x1 == 0)
                {
                    coords.x1 = 0;
                    coords.y1 = UNDERGROUND;
                    coords.x2 = 30;
                    coords.y2 = UNDERGROUND;
                }
                else
                {
                    if (dir == directions.UP)
                    {
                        coords.x1 = coords.x2;
                        coords.y1 = coords.y2;
                        coords.x2 = coords.x1 + rnd.Next(40, 70);
                    }
                    else
                    {
                        if (DrawLineCityEnd(w))
                        {
                            coords.x1 = coords.x2;
                            coords.y1 = coords.y2;
                            coords.x2 = coords.x1 + 100;
                            Point point3 = new Point();
                            point3.X = coords.x1;
                            point3.Y = coords.y1;
                            points[c] = point3;
                            Point point4 = new Point();
                            point4.X = coords.x2;
                            point4.Y = coords.y2;
                            points[c + 1] = point4;
                            base.g.DrawLine(base.pen, coords.x1, coords.y1, coords.x2, coords.y2);
                            return true;
                        }
                        else
                        {
                            coords.x1 = coords.x2;
                            coords.y1 = coords.y2;
                            coords.x2 = coords.x1 + BETWEEN;
                        }
                    }
                }
            }
            else if (direction == directions.LEFT)
            {

            }
            else if (direction == directions.UP)
            {
                coords.x1 = coords.x2;
                coords.y1 = coords.y2;
                coords.y2 = rnd.Next(180, 280);
            }
            else //Направление вниз
            {
                coords.x1 = coords.x2;
                coords.y1 = coords.y2;
                coords.y2 = UNDERGROUND;
                houses += 1;
            }

            Point point1 = new Point();
            point1.X = coords.x1;
            point1.Y = coords.y1;
            points[c] = point1;
            Point point2 = new Point();
            point2.X = coords.x2;
            point2.Y = coords.y2;
            points[c + 1] = point2;
            base.g.DrawLine(base.pen, coords.x1, coords.y1, coords.x2, coords.y2);
            return false;
        }

        public bool DrawLineCityEnd(int? w)
        {
            if (w != null)
            {
                if (coords.x2 > w - 90 && houses >= 9)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class PaintArea:CoreDraw
    {

    }
}

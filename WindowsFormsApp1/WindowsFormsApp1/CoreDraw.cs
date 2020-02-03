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
        public Brush brush;
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
        public int BETWEEN = 11;
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

    public class PaintArea : CoreDraw
    {
        //Конструктор класса
        public PaintArea()
        {
            brush = new SolidBrush(Color.FromArgb(55, 82, 99));
            pen = new Pen(brush);
        }

        string direction = "right";
        string RIGHT = "right";
        string UP = "up";

        public Point[] PaintCity(Point[] p2, int w, int h)
        {
            Point[] points = new Point[p2.Length + 2];
            for (int j = 0; j < p2.Length; j++)
            {
                if (j < p2.Length - 1)
                {
                    if (p2[j].Y == p2[j + 1].Y)
                    {
                        if (direction == UP)
                        {
                            points[j].X = p2[j].X + 1;
                            points[j].Y = p2[j].Y + 1;
                            direction = RIGHT;
                        }
                        else
                        {
                            points[j].X = p2[j].X;
                            points[j].Y = p2[j].Y + 1;
                            direction = RIGHT;
                        }
                    }
                    else
                    {
                        if (p2[j].Y > p2[j + 1].Y)
                        {
                            points[j].X = p2[j].X + 1;
                            points[j].Y = p2[j].Y + 1;
                            direction = UP;
                        }
                        else
                        {
                            points[j].X = p2[j].X;
                            points[j].Y = p2[j].Y + 1;
                            direction = "none";
                        }
                    }
                }
                else
                {
                    points[j].X = p2[j].X;
                    points[j].Y = p2[j].Y + 1;
                }
            }

            //Заполняем две крайние точки, которые равны ширине и высоте Bitmap
            points[points.Length - 2].X = w;
            points[points.Length - 2].Y = h;
            points[points.Length - 1].X = 0;
            points[points.Length - 1].Y = h;
            return points;
        }

        public List<String> windowsPoints = new List<String>();

        public int DrawWindows(Point[] p2, int pos, string color)
        {
            switch (color)
            {
                case "Желтый": brush = new SolidBrush(Color.Yellow); break;
                case "Зеленый": brush = new SolidBrush(Color.Green); break;
                case "Красный": brush = new SolidBrush(Color.Red); break;
                case "Черный": brush = new SolidBrush(Color.Black); break;
                case "Белый": brush = new SolidBrush(Color.White); break;
                case "Фиолетовый": brush = new SolidBrush(Color.Violet); break;
                case "Розовый": brush = new SolidBrush(Color.Pink); break;
                default: brush = new SolidBrush(Color.Yellow); break;
            }

            bool up = false;
            for (int j = pos; j < p2.Length; j++)
            {
                if (p2[j].X != 0 || p2[j].Y != 0)
                    if (j < p2.Length - 1)
                    {
                        if (p2[j].Y == p2[j + 1].Y)
                        {
                            if (up)
                            {
                                CalculateWindows(p2[j].X, p2[j].Y, p2[j + 1].X, p2[j - 1].Y);
                                return j + 1;
                            }
                            up = false;
                        }
                        if (p2[j].Y > p2[j + 1].Y)
                        {
                            up = true;
                        }
                    }
            }
            return p2.Length;
        }

        public void CalculateWindows(int x1, int y1, int x2, int y2, bool end = false)
        {
            //Высота дома
            int height = y2 - y1;
            //Ширина дома
            int width = x2 - x1;
            //Отнимаем от краев дома 10 пикселей
            int windows_and_intervalsW = width - 10;
            //Отнимаем от краев дома 10 пикселей
            int windows_and_intervalsH = height - 10;
            //Высота окна и промежуток между окнами
            int hW = 5;
            //Ширина окна
            int wW = 10;
            //Количество окон по горизонтали
            int windowsCountH = Convert.ToInt32(Math.Floor((decimal)windows_and_intervalsW / (hW + wW)));
            //Количество окон по вертикали
            int windowsCountV = Convert.ToInt32(Math.Floor((decimal)windows_and_intervalsH / (hW + hW)));
            //Количество промежутков между окнами
            int forWindows = windows_and_intervalsW - (windowsCountH - 1) * hW;
            //Ширина окна
            int windowWidth = Convert.ToInt32(Math.Floor((decimal)forWindows / windowsCountH));
            int x = x1;

            for (int j = 0; j < windowsCountV; j++)
            {
                for (int i = 0; i < windowsCountH; i++)
                {
                    Point[] p = new Point[4];
                    p[0].X = x1 + hW;
                    p[0].Y = y1 + hW;
                    p[1].X = x1 + hW + windowWidth;
                    p[1].Y = y1 + hW;
                    p[2].X = x1 + hW + windowWidth;
                    p[2].Y = y1 + hW + hW;
                    p[3].X = x1 + hW;
                    p[3].Y = y1 + hW + hW;
                    g.DrawPolygon(pen, p);
                    g.FillPolygon(brush, p);
                    x1 = x1 + hW + windowWidth;
                    //windowsPoints.Add("[0]=[" + p[0].X + ";" + p[0].Y + "]");
                    //windowsPoints.Add("[1]=[" + p[1].X + ";" + p[1].Y + "]");
                    //windowsPoints.Add("[2]=[" + p[2].X + ";" + p[2].Y + "]");
                    //windowsPoints.Add("[3]=[" + p[3].X + ";" + p[3].Y + "]");
                }
                //Следующий ряд окон
                y1 = y1 + wW;
                x1 = x;
            }
        }
    }

    public class Moon : CoreDraw
    {
        public Moon()
        {
            pen = new Pen(Color.FromArgb(246, 238, 236));
            brush = new SolidBrush(Color.FromArgb(246, 238, 236));
        }

        public Point[] point;

        public void DrawMoon()
        {
            point = new Point[1];
            point[0].X = 520;
            point[0].Y = 50;
            int width = 30;
            int height = 30;
            base.g.DrawEllipse(pen, point[0].X, point[0].Y, width, height);
            base.g.FillEllipse(brush, point[0].X, point[0].Y, width, height);
            this.DrawMoonSpots(point, width, height);
        }

        private void DrawMoonSpots(Point[] p, int w, int h)
        {
            pen = new Pen(Color.FromArgb(177, 177, 177));
            brush = new SolidBrush(Color.FromArgb(177, 177, 177));
            Point[] spot1 = new Point[1];
            spot1[0].X = p[0].X + 3;
            spot1[0].Y = p[0].Y + 11;
            base.g.DrawEllipse(pen, spot1[0].X, spot1[0].Y, 3, 4);
            base.g.FillEllipse(brush, spot1[0].X, spot1[0].Y, 4, 4);
            Point[] spot2 = new Point[1];
            spot2[0].X = p[0].X + 7;
            spot2[0].Y = p[0].Y + 16;
            base.g.DrawEllipse(pen, spot2[0].X, spot2[0].Y, 3, 5);
            base.g.FillEllipse(brush, spot2[0].X, spot2[0].Y, 4, 5);
            Point[] spot3 = new Point[1];
            spot3[0].X = p[0].X + 11;
            spot3[0].Y = p[0].Y + 13;
            base.g.DrawEllipse(pen, spot3[0].X, spot3[0].Y, 6, 7);
            base.g.FillEllipse(brush, spot3[0].X, spot3[0].Y, 6, 7);
            Point[] spot4 = new Point[1];
            spot4[0].X = p[0].X + 15;
            spot4[0].Y = p[0].Y + 2;
            base.g.DrawEllipse(pen, spot4[0].X, spot4[0].Y, 10, 11);
            base.g.FillEllipse(brush, spot4[0].X, spot4[0].Y, 10, 11);
        }
    }

    public class Sky:CoreDraw
    {
        public Sky()
        {
            pen = new Pen(Color.DarkBlue);
            brush = new SolidBrush(Color.FromArgb(30, 36, 48));
        }
        public void PaintSky(Point[] p)
        {
            base.g.FillPolygon(brush, p);
        }
    }
}

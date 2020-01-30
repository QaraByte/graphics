﻿using System;
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
        //Конструктор класса
        public PaintArea()
        {
            brush = new SolidBrush(Color.DarkBlue);
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

        public Point[] windowsPoints;

        public int DrawWindows(Point[] p2, int pos)
        {
            brush = new SolidBrush(Color.Yellow);
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
                                //Длина крыши минус расстояние по бокам по 5 пикселей
                                double distanceH = p2[j + 1].X - p2[j].X - 10;
                                //Количество домов=длина крыши/15, 15=окно+расстояние до границы слева
                                int windowsHorizontal = Convert.ToInt32(Math.Floor(distanceH / 15));
                                //Высота дома минус расстояние сверху и снизу по 5 пикселей
                                double distanceV = p2[j - 1].Y - p2[j].Y - 10;
                                int windowsVerticital = Convert.ToInt32(Math.Floor(distanceV / 10));
                                int to_left = 5;
                                int to_end = 10;

                                for (int i = 1; i <= windowsHorizontal; i++)
                                {
                                    //Первый ряд
                                    //Определяем координаты для окон
                                    windowsPoints = new Point[4];
                                    switch (i)
                                    {
                                        //Первое окно
                                        case 1:
                                            windowsPoints[0].X = p2[j].X + to_left;
                                            windowsPoints[0].Y = p2[j].Y + to_left;
                                            windowsPoints[1].X = p2[j].X + to_left + to_end;
                                            windowsPoints[1].Y = p2[j].Y + to_left;
                                            windowsPoints[2].X = p2[j].X + to_left + to_end;
                                            windowsPoints[2].Y = p2[j].Y + to_end;
                                            windowsPoints[3].X = p2[j].X + to_left;
                                            windowsPoints[3].Y = p2[j].Y + to_end;
                                            base.g.DrawPolygon(pen, windowsPoints);
                                            base.g.FillPolygon(brush, windowsPoints);
                                            break;
                                        //Второе окно
                                        case 2:
                                            windowsPoints[0].X = p2[j].X + to_left + to_end + to_left;
                                            windowsPoints[0].Y = p2[j].Y + to_left;
                                            windowsPoints[1].X = p2[j].X + i * (to_left + to_end);
                                            windowsPoints[1].Y = p2[j].Y + to_left;
                                            windowsPoints[2].X = p2[j].X + i * (to_left + to_end);
                                            windowsPoints[2].Y = p2[j].Y + to_end;
                                            windowsPoints[3].X = p2[j].X + to_left + to_end + to_left;
                                            windowsPoints[3].Y = p2[j].Y + to_end;
                                            base.g.DrawPolygon(pen, windowsPoints);
                                            base.g.FillPolygon(brush, windowsPoints);
                                            break;
                                        //Третье окно
                                        case 3:
                                            windowsPoints[0].X = p2[j].X + (i - 1) * (to_left + to_end) + to_left;
                                            windowsPoints[0].Y = p2[j].Y + to_left;
                                            windowsPoints[1].X = p2[j].X + i * (to_left + to_end);
                                            windowsPoints[1].Y = p2[j].Y + to_left;
                                            windowsPoints[2].X = p2[j].X + i * (to_left + to_end);
                                            windowsPoints[2].Y = p2[j].Y + to_end;
                                            windowsPoints[3].X = p2[j].X + (i - 1) * (to_left + to_end) + to_left;
                                            windowsPoints[3].Y = p2[j].Y + to_end;
                                            base.g.DrawPolygon(pen, windowsPoints);
                                            base.g.FillPolygon(brush, windowsPoints);
                                            break;
                                    }
                                }

                                int to_top_window = 5;
                                int to_bottom_window = 10;

                                for (int k = 2; k <= windowsVerticital; k++)
                                {
                                    //Определяем координаты для окон
                                    windowsPoints = new Point[4];
                                    switch (k)
                                    {
                                        //Второй ряд
                                        case 2:
                                            windowsPoints[0].X = p2[j].X + to_left;
                                            windowsPoints[0].Y = p2[j].Y + to_bottom_window + to_top_window;
                                            windowsPoints[1].X = p2[j].X + to_left + to_end;
                                            windowsPoints[1].Y = p2[j].Y + to_bottom_window + to_top_window;
                                            windowsPoints[2].X = p2[j].X + to_left + to_end;
                                            windowsPoints[2].Y = p2[j].Y + to_bottom_window + to_bottom_window;
                                            windowsPoints[3].X = p2[j].X + to_left;
                                            windowsPoints[3].Y = p2[j].Y + to_bottom_window + to_bottom_window;
                                            base.g.DrawPolygon(pen, windowsPoints);
                                            base.g.FillPolygon(brush, windowsPoints);
                                            break;
                                        case 3:
                                            windowsPoints[0].X = p2[j].X + to_left + to_end + to_left;
                                            windowsPoints[0].Y = p2[j].Y + to_bottom_window + to_top_window;
                                            windowsPoints[1].X = p2[j].X + k * (to_left + to_end);
                                            windowsPoints[1].Y = p2[j].Y + to_bottom_window + to_top_window;
                                            windowsPoints[2].X = p2[j].X + k * (to_left + to_end);
                                            windowsPoints[2].Y = p2[j].Y + to_bottom_window + to_bottom_window;
                                            windowsPoints[3].X = p2[j].X + to_left + to_end + to_left;
                                            windowsPoints[3].Y = p2[j].Y + to_bottom_window + to_bottom_window;
                                            base.g.DrawPolygon(pen, windowsPoints);
                                            base.g.FillPolygon(brush, windowsPoints);
                                            break;
                                    }
                                }
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
    }
}

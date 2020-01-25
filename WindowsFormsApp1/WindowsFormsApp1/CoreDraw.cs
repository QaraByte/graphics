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
        /// <summary>
        /// Нижний предел
        /// </summary>
        public int UNDERGROUND;
        
        public Pen pen;     
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
        public int BETWEEN = 10;
        public int houses = 0;
        Random rnd = new Random();
        public Coords coords;
        Directions directions = new Directions();
        /// <summary>
        /// Предыдущее направление
        /// </summary>
        public string pastDir;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="color">Цвет карандаша</param>
        /// <param name="w">Ширина карандаша</param>
        public CoreDrawCity(Color color, int w)
        {
            pen = new Pen(color);
            pen.Width = w;
            base.UNDERGROUND = 300;
            directions.RIGHT = "right";
            coords = new Coords();
        }

        public void DrawLineCity(int c)
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
                    coords.x1 = 1;
                    coords.y1 = UNDERGROUND;
                    coords.x2 = 20;
                    coords.y2 = UNDERGROUND;
                }
                else
                {
                    if (pastDir == directions.UP)
                    {
                        coords.x1 = coords.x2;
                        coords.y1 = coords.y2;
                        coords.x2 = coords.x1 + rnd.Next(40, 70);
                        pastDir = directions.RIGHT;
                    }
                    else
                    {
                        coords.x1 = coords.x2;
                        coords.y1 = coords.y2;
                        coords.x2 = coords.x1 + BETWEEN;
                        pastDir = directions.RIGHT;
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
                coords.x2 = coords.x1;
                coords.y2 = rnd.Next(180, 280);
                pastDir = directions.UP;
            }
            else //Направление вниз
            {
                coords.x1 = coords.x2;
                coords.y1 = coords.y2;
                coords.x2 = coords.x1;
                coords.y2 = UNDERGROUND;
                houses += 1;
                pastDir = directions.DOWN;
            }
        }
    }
}

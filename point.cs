using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    class Point
    {
        // Координата X точки
        public int X { get; set; }

        // Координата Y точки
        public int Y { get; set; }

        // Символ, представляющий точку при отрисовке
        public char sym { get; set; }

        // Конструктор без параметров
        public Point()
        {
        }

        // Конструктор с параметрами для задания координат и символа
        public Point(int x, int y, char sym)
        {
            X = x;
            Y = y;
            this.sym = sym;
        }

        // Конструктор копирования для создания точки на основе другой точки
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            sym = p.sym;
        }

        // Метод для перемещения точки на заданное смещение в указанном направлении
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                X += offset;
            }
            else if (direction == Direction.LEFT)
            {
                X -= offset;
            }
            else if (direction == Direction.UP)
            {
                Y -= offset;
            }
            else if (direction == Direction.DOWN)
            {
                Y += offset;
            }
        }

        // Метод для проверки пересечения текущей точки с другой точкой
        public bool IsHit(Point p)
        {
            return X == p.X && Y == p.Y;
        }

        // Метод для отрисовки точки на консоли
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(sym);
        }

        // Метод для очистки точки (замены символа на пробел) на консоли
        public void Clear()
        {
            sym = ' ';
            Draw(); // Перерисовываем точку после очистки
        }

        // Переопределение метода ToString() для возвращения строкового представления точки
        public override string ToString()
        {
            return X + ", " + Y + ", " + sym;
        }
    }
}

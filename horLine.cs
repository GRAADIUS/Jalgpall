using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    // Определяем класс horLine, который наследует от класса Figure
    class horLine : Figure
    {
        // Конструктор класса horLine принимает координаты левой и правой границ линии (xLeft и xRight),
        // координату y, на которой будет нарисована линия, и символ sym, которым будет отрисована линия
        public horLine(int xLeft, int xRight, int y, char sym)
        {
            // Инициализируем список точек pList
            pList = new List<Point>();

            // Проходим по всем x координатам, начиная с xLeft и заканчивая xRight
            for (int x = xLeft; x <= xRight; x++)
            {
                // Создаем новую точку с координатами (x, y) и символом sym
                Point p = new Point(x, y, sym);

                // Добавляем созданную точку в список pList
                pList.Add(p);
            }
        }
    }
}

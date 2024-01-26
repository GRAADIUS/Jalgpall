using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    // Создаем класс vertLine (вертикальная линия), который наследует функциональность класса Figure
    class vertLine : Figure
    {
        // Конструктор класса, который принимает параметры для определения вертикальной линии
        public vertLine(int yUp, int yDown, int x, char sym)
        {
            // Инициализируем список точек, представляющих линию
            pList = new List<Point>();

            // Цикл для создания точек линии с заданными координатами и символом
            for (int y = yUp; y <= yDown; y++)
            {
                // Создаем новую точку с координатами (x, y) и заданным символом
                Point p = new Point(x, y, sym);

                // Добавляем созданную точку в список точек линии
                pList.Add(p);
            }
        }
    }
}

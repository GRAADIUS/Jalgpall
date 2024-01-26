using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    // Класс Figure представляет базовую фигуру, которую можно нарисовать и проверить на пересечение с другой фигурой.
    class Figure
    {
        // Список точек, определяющих фигуру.
        protected List<Point> pList;

        // Метод для отрисовки фигуры, вызывает метод Draw() для каждой точки в списке pList.
        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        // Метод для определения пересечения данной фигуры с другой фигурой.
        internal bool IsHit(Figure figure)
        {
            // Перебираем все точки текущей фигуры.
            foreach (var p in pList)
            {
                // Если хотя бы одна точка текущей фигуры пересекается с другой фигурой, возвращаем true.
                if (figure.IsHit(p))
                    return true;
            }
            // Если ни одна точка текущей фигуры не пересекается с другой фигурой, возвращаем false.
            return false;
        }

        // Приватный метод для определения пересечения точки с текущей фигурой.
        private bool IsHit(Point point)
        {
            // Перебираем все точки текущей фигуры.
            foreach (var p in pList)
            {
                // Если точка совпадает с какой-либо точкой текущей фигуры, возвращаем true.
                if (p.IsHit(point))
                    return true;
            }
            // Если точка не пересекается ни с одной точкой текущей фигуры, возвращаем false.
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    // Класс, представляющий стены на игровом поле
    internal class Walls
    {
        // Список стен
        List<Figure> wallList;

        // Конструктор, инициализирующий стены по заданным параметрам ширины и высоты карты
        public Walls(int mapWidth, int mapHeight)
        {
            // Создание нового списка стен
            wallList = new List<Figure>();

            // Создание горизонтальной линии верхней границы
            horLine upLine = new horLine(0, mapWidth - 2, 0, '+');

            // Создание горизонтальной линии нижней границы
            horLine downLine = new horLine(0, mapWidth - 2, mapHeight - 1, '+');

            // Создание вертикальной линии левой границы
            vertLine leftLine = new vertLine(0, mapHeight - 1, 0, '+');

            // Создание вертикальной линии правой границы
            vertLine rightLine = new vertLine(0, mapHeight - 1, mapWidth - 2, '+');

            // Добавление стен в список
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        // Метод для проверки столкновения фигуры с какой-либо из стен
        internal bool IsHit(Figure figure)
        {
            // Проверка каждой стены на столкновение с фигурой
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true; // Если столкновение обнаружено, возвращается true
                }
            }
            return false; // Если столкновение не обнаружено, возвращается false
        }

        // Метод для отрисовки стен
        public void Draw()
        {
            // Отрисовка каждой стены
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}

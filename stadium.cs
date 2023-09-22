namespace Football
{
    public class Stadium // Класс, описывающий стадион
    {
        public Stadium(int width, int height) // Конструктор класса, устанавливающий ширину и высоту стадиона
        {
            Width = width; // Устанавливаем ширину стадиона
            Height = height; // Устанавливаем высоту стадиона
        }

        public int Width { get; } // Свойство для получения ширины стадиона

        public int Height { get; } // Свойство для получения высоты стадиона

        public bool IsIn(double x, double y) // Метод, определяющий, находятся ли координаты (x, y) в пределах стадиона
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
            // Возвращаем true, если координаты находятся в пределах стадиона (x от 0 до ширины и y от 0 до высоты)
        }
    }
}

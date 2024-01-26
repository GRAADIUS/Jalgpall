namespace Football
{
    // Класс, представляющий стадион
    public class Stadium
    {
        // Конструктор класса Stadium, принимающий ширину и высоту стадиона
        public Stadium(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // Свойство, представляющее ширину стадиона (только для чтения)
        public int Width { get; }

        // Свойство, представляющее высоту стадиона (только для чтения)
        public int Height { get; }

        // Метод, определяющий, находится ли точка с координатами (x, y) внутри стадиона
        public bool IsIn(double x, double y)
        {
            // Возвращает true, если x и y находятся в пределах от 0 до Width и от 0 до Height соответственно
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}

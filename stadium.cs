namespace Football;

public class Stadium // система стадиона
{
    public Stadium(int width, int height) // установка ширины и высоты стадиона
    {
        Width = width; // ширина
        Height = height; // высота
    }

    public int Width { get; } // получение глобальной переменной высоты

    public int Height { get; } // получение глобальной переменной ширины

    public bool IsIn(double x, double y) //
    {
        return x >= 0 && x < Width && y >= 0 && y < Height; // 
    }
}
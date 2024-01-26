namespace Football;

// Класс, представляющий мяч в футбольной игре
public class Ball
{
    // Публичные свойства для доступа к координатам X и Y мяча
    public double X { get; private set; }
    public double Y { get; private set; }

    // Приватные переменные для хранения скорости мяча по осям X и Y
    private double _vx, _vy;

    // Ссылка на объект игры, в которой находится мяч
    private Game _game;

    // Метод вызывается при достижении нулевых координат мяча
    private void OnZero()
    {
        // Устанавливаем координаты мяча в центр поля игры и обнуляем скорость
        X = _game.Stadium.Width / 2;
        Y = _game.Stadium.Height / 2;
        _vx = _vy = 0;
    }

    // Конструктор класса, принимающий начальные координаты мяча и объект игры
    public Ball(double x, double y, Game game)
    {
        _game = game;
        X = x;
        Y = y;
    }

    // Метод для установки скорости мяча по осям X и Y
    public void SetSpeed(double vx, double vy)
    {
        _vx = vx;
        _vy = vy;
    }

    // Метод для перемещения мяча на основе его текущей скорости
    public void Move()
    {
        // Вычисляем новые координаты мяча на основе его текущей скорости
        double newX = X + _vx;
        double newY = Y + _vy;

        // Проверяем, остается ли мяч в пределах игрового поля
        if (_game.Stadium.IsIn(newX, newY))
        {
            // Если мяч остается в пределах поля, обновляем его координаты
            X = newX;
            Y = newY;
        }
        else
        {
            // Если мяч выходит за пределы поля, вызываем метод OnZero для его возвращения в центр поля
            OnZero();
        }
    }
}

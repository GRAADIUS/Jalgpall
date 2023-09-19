namespace Football;

public class Ball // система мяча
{
    public double X { get; private set; } // получение позиции глобальной переменной мяча 
    public double Y { get; private set; } // получение позиции глобальной переменной мяча 

    private double _vx, _vy; // положение движения мяча 

    private Game _game; // переменная игры

    public Ball(double x, double y, Game game) // данные мяча 
    {
        _game = game; // получение переменной игры 
        X = x; // получение положения мяча 
        Y = y; // получение положения мяча 
    }

    public void SetSpeed(double vx, double vy) // установка скорости мяча 
    {
        _vx = vx; // получение направления мяча 
        _vy = vy; // получение направления мяча 
    }

    public void Move() // движение 
    {
        double newX = X + _vx; // новая переменная положения мяча после удара 
        double newY = Y + _vy; // новая переменная положения мяча после удара 
        if (_game.Stadium.IsIn(newX, newY)) // если скорость мяча равна 0, мяч остановиться
        // положение мяча обновляется иначе останавливается 
        {
            X = newX;
            Y = newY;
        }
        else
        {
            _vx = 0;
            _vy = 0;
        }
    }

}
using System; // Подключение пространства имен System

namespace Football // Объявление пространства имен Football
{
    public class Player // Объявление класса Player
    {
        public string Name { get; } // Имя игрока (свойство только для чтения)

        public double X { get; private set; } // Положение игрока на стадионе (координата X)
        public double Y { get; private set; } // Положение игрока на стадионе (координата Y)
        private double _vx, _vy; // Смещение на координатных осях X и Y

        public Team? Team { get; set; } = null; // Команда, в которой играет игрок (может быть null)

        private const double MaxSpeed = 5; // Максимальная скорость игрока
        private const double MaxKickSpeed = 25; // Максимальная сила удара
        private const double BallKickDistance = 10; // Дистанция для удара мяча

        private Random _random = new Random(); // Генератор случайных чисел

        // Конструктор класса, принимающий имя игрока
        public Player(string name)
        {
            Name = name;
        }

        // Конструктор класса, принимающий имя игрока, начальные координаты и команду
        public Player(string name, double x, double y, Team team)
        {
            Name = name;
            X = x;
            Y = y;
            Team = team;
        }

        // Метод для установки позиции игрока
        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Метод для получения абсолютной позиции игрока на поле
        public (double, double) GetAbsolutePosition()
        {
            return Team!.Game.GetPositionForTeam(Team, X, Y);
        }

        // Метод для вычисления расстояния до мяча
        public double GetDistanceToBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy); // Расстояние до мяча по теореме Пифагора
        }

        // Метод для перемещения игрока в направлении мяча
        public void MoveTowardsBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed; // Отношение расстояния до мяча к максимальной скорости
            _vx = dx / ratio;
            _vy = dy / ratio;
        }

        // Метод для перемещения игрока
        public void Move()
        {
            if (Team.GetClosestPlayerToBall() != this)
            {
                _vx = 0;
                _vy = 0;
            }

            if (GetDistanceToBall() < BallKickDistance) // Если игрок находится достаточно близко к мячу, он ударяет
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(), // Генерируется случайная сила удара
                    MaxKickSpeed * (_random.NextDouble() - 0.5) // Генерируется случайное направление удара
                );
            }

            var newX = X + _vx;
            var newY = Y + _vy;
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);

            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                _vx = _vy = 0; // Если игрок выходит за границы стадиона, его скорость обнуляется
            }
        }
    }
}

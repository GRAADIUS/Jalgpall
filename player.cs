using System;

namespace Football
{
    // Класс, представляющий игрока
    public class Player
    {
        // Имя игрока (неизменяемое)
        public string Name { get; }

        // Текущие координаты игрока
        public double X { get; private set; }
        public double Y { get; private set; }

        // Скорости по осям X и Y для перемещения игрока
        private double _vx, _vy;

        // Команда, к которой принадлежит игрок (может быть null)
        public Team? Team { get; set; } = null;

        // Максимальная скорость перемещения игрока
        private const double MaxSpeed = 5;

        // Максимальная скорость удара мяча
        private const double MaxKickSpeed = 25;

        // Максимальное расстояние для удара мяча
        private const double BallKickDistance = 10;

        // Генератор случайных чисел
        private Random _random = new Random();

        // Конструктор класса с указанием имени игрока
        public Player(string name)
        {
            Name = name;
        }

        // Конструктор класса с указанием имени, начальных координат и команды игрока
        public Player(string name, double x, double y, Team team)
        {
            Name = name;
            X = x;
            Y = y;
            Team = team;
        }

        // Установка новых координат для игрока
        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Получение абсолютных координат игрока на поле
        public (double, double) GetAbsolutePosition()
        {
            return Team!.Game.GetPositionForTeam(Team, X, Y);
        }

        // Получение расстояния до мяча
        public double GetDistanceToBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Перемещение игрока в направлении мяча
        public void MoveTowardsBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
            _vx = dx / ratio;
            _vy = dy / ratio;
        }

        // Перемещение игрока
        public void Move()
        {
            // Если текущий игрок не ближайший к мячу, остановиться
            if (Team.GetClosestPlayerToBall() != this)
            {
                _vx = 0;
                _vy = 0;
            }

            // Если расстояние до мяча меньше допустимого для удара, ударить по мячу
            if (GetDistanceToBall() < BallKickDistance)
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(),
                    MaxKickSpeed * (_random.NextDouble() - 0.5)
                );
            }

            // Предполагаемые новые координаты игрока
            var newX = X + _vx;
            var newY = Y + _vy;
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);

            // Проверка, находится ли игрок в пределах игрового поля
            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
            {
                // Если да, обновить координаты игрока
                X = newX;
                Y = newY;
            }
            else
            {
                // Если нет, остановиться
                _vx = _vy = 0;
            }
        }
    }
}

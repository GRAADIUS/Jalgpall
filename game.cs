namespace Football
{
    public class Game
    {
        // Класс, представляющий футбольный матч

        // Домашняя команда
        public Team HomeTeam { get; }

        // Гостевая команда
        public Team AwayTeam { get; }

        // Стадион
        public Stadium Stadium { get; }

        // Мяч
        public Ball Ball { get; private set; }

        // Конструктор класса Game
        public Game(Team homeTeam, Team awayTeam, Stadium stadium)
        {
            // Инициализация полей класса
            HomeTeam = homeTeam;
            homeTeam.Game = this;
            AwayTeam = awayTeam;
            awayTeam.Game = this;
            Stadium = stadium;
        }

        // Метод запуска матча
        public void Start()
        {
            // Создание мяча в центре поля
            Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this);

            // Установка начальных позиций игроков команд
            HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height);
            AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height);
        }

        // Получение позиции для гостевой команды (отраженной относительно ширины и высоты стадиона)
        private (double, double) GetPositionForAwayTeam(double x, double y)
        {
            return (Stadium.Width - x, Stadium.Height - y);
        }

        // Получение позиции для определенной команды (домашней или гостевой)
        public (double, double) GetPositionForTeam(Team team, double x, double y)
        {
            return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
        }

        // Получение позиции мяча для определенной команды
        public (double, double) GetBallPositionForTeam(Team team)
        {
            return GetPositionForTeam(team, Ball.X, Ball.Y);
        }

        // Установка скорости мяча для определенной команды
        public void SetBallSpeedForTeam(Team team, double vx, double vy)
        {
            if (team == HomeTeam)
            {
                Ball.SetSpeed(vx, vy);
            }
            else
            {
                Ball.SetSpeed(-vx, -vy);
            }
        }

        // Метод, отвечающий за ход матча (движение игроков и мяча)
        public void Move()
        {
            HomeTeam.Move();
            AwayTeam.Move();
            Ball.Move();
        }
    }
}

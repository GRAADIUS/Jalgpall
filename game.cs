namespace Football
{
    public class Game
    {
        public Team HomeTeam { get; } // Свойство для доступа к домашней команде.
        public Team AwayTeam { get; } // Свойство для доступа к гостевой команде.
        public Stadium Stadium { get; } // Свойство для доступа к стадиону.
        public Ball Ball { get; private set; } // Свойство для доступа к мячу с приватным сеттером.

        // Конструктор класса Game, который принимает домашнюю и гостевую команды и стадион.
        public Game(Team homeTeam, Team awayTeam, Stadium stadium)
        {
            HomeTeam = homeTeam;
            homeTeam.Game = this;
            AwayTeam = awayTeam;
            awayTeam.Game = this;
            Stadium = stadium;
        }

        // Метод для начала игры.
        public void Start()
        {
            Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this); // Создание мяча в центре стадиона.
            HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height); // Начало игры для домашней команды.
            AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height); // Начало игры для гостевой команды.
        }

        // Приватный метод для получения позиции для гостевой команды относительно стадиона.
        private (double, double) GetPositionForAwayTeam(double x, double y)
        {
            return (Stadium.Width - x, Stadium.Height - y);
        }

        // Метод для получения позиции для конкретной команды (домашней или гостевой).
        public (double, double) GetPositionForTeam(Team team, double x, double y)
        {
            return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
        }

        // Метод для получения позиции мяча для конкретной команды.
        public (double, double) GetBallPositionForTeam(Team team)
        {
            return GetPositionForTeam(team, Ball.X, Ball.Y);
        }

        // Метод для установки скорости мяча для конкретной команды.
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

        // Метод для выполнения движения (хода) игры.
        public void Move()
        {
            HomeTeam.Move(); // Двигаем домашнюю команду.
            AwayTeam.Move(); // Двигаем гостевую команду.
            Ball.Move(); // Двигаем мяч.
        }
    }
}

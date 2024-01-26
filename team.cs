using System;
using System.Collections.Generic;

namespace Football
{
    public class Team
    {
        // Список игроков в команде
        public List<Player> Players { get; } = new List<Player>();

        // Название команды
        public string Name { get; private set; }

        // Ссылка на игровое поле, на котором происходит игра
        public Game Game { get; set; }

        // Конструктор класса Team, принимающий название команды
        public Team(string name)
        {
            Name = name;
        }

        // Метод для начала игры, устанавливает начальные позиции игроков случайным образом
        public void StartGame(int width, int height)
        {
            Random rnd = new Random();
            foreach (var player in Players)
            {
                player.SetPosition(
                    rnd.NextDouble() * width,
                    rnd.NextDouble() * height
                );
            }
        }

        // Метод для добавления игрока в команду
        public void AddPlayer(Player player)
        {
            // Проверяем, что игрок не находится уже в другой команде
            if (player.Team != null) return;
            Players.Add(player);
            // Устанавливаем ссылку на текущую команду у игрока
            player.Team = this;
        }

        // Метод для получения позиции мяча относительно команды
        public (double, double) GetBallPosition()
        {
            return Game.GetBallPositionForTeam(this);
        }

        // Метод для установки скорости мяча для команды
        public void SetBallSpeed(double vx, double vy)
        {
            Game.SetBallSpeedForTeam(this, vx, vy);
        }

        // Метод для получения ближайшего игрока к мячу
        public Player GetClosestPlayerToBall()
        {
            Player closestPlayer = Players[0];
            double bestDistance = Double.MaxValue;
            foreach (var player in Players)
            {
                // Рассчитываем расстояние от текущего игрока до мяча
                var distance = player.GetDistanceToBall();
                // Если расстояние меньше лучшего расстояния, обновляем данные ближайшего игрока
                if (distance < bestDistance)
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }
            return closestPlayer;
        }

        // Метод для передвижения игроков
        public void Move()
        {
            // Перемещаем ближайшего игрока к мячу
            GetClosestPlayerToBall().MoveTowardsBall();
            // Перемещаем остальных игроков
            Players.ForEach(player => player.Move());
        }
    }
}

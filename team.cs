using System;
using System.Collections.Generic;

namespace Football
{
    public class Team
    {
        public List<Player> Players { get; } = new List<Player>(); // Список игроков в команде
        public string Name { get; private set; } // Название команды
        public Game Game { get; set; } // Ссылка на игру, в которой участвует команда

        // Конструктор класса Team
        public Team(string name)
        {
            Name = name;
        }

        // Метод для начала игры, устанавливает начальные позиции игроков на поле
        public void StartGame(int width, int height)
        {
            Random rnd = new Random();
            // Устанавливаем начальные позиции игроков в случайных координатах на поле
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
            if (player.Team != null) return; // Если игрок уже в другой команде, не добавляем его
            Players.Add(player); // Добавляем игрока в список игроков команды
            player.Team = this; // Устанавливаем ссылку на текущую команду у игрока
        }

        // Метод для получения позиции мяча для текущей команды
        public (double, double) GetBallPosition()
        {
            return Game.GetBallPositionForTeam(this); // Получаем позицию мяча для текущей команды из игры
        }

        // Метод для установки скорости мяча для текущей команды в игре
        public void SetBallSpeed(double vx, double vy)
        {
            Game.SetBallSpeedForTeam(this, vx, vy); // Устанавливаем скорость мяча для текущей команды в игре
        }

        // Метод для получения ближайшего игрока к мячу
        public Player GetClosestPlayerToBall()
        {
            Player closestPlayer = Players[0];
            double bestDistance = Double.MaxValue;
            // Находим игрока из команды, находящегося ближе всего к мячу
            foreach (var player in Players)
            {
                var distance = player.GetDistanceToBall();
                if (distance < bestDistance)
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }
            return closestPlayer;
        }

        // Метод для движения игроков команды
        public void Move()
        {
            // Двигаем игрока, находящегося ближе всего к мячу, в направлении мяча
            GetClosestPlayerToBall().MoveTowardsBall();
            // Затем двигаем всех игроков команды
            Players.ForEach(player => player.Move());
        }
    }
}

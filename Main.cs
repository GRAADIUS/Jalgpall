using Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    internal class main
    {
        public static void Main()
        {
            // Создание команд домашней и гостевой
            Team homeTeam = new Team("Домашняя Команда");
            Team awayTeam = new Team("Гостевая Команда");

            // Создание стадиона
            Stadium stadium = new Stadium(80, 20);

            // Создание игры с заданными командами и стадионом
            Game game = new Game(homeTeam, awayTeam, stadium);

            // Добавление игроков в команды
            for (int i = 1; i <= 22; i++)
            {
                Player player = new Player($"Игрок {i}");
                // Первые 11 игроков добавляются в домашнюю команду, остальные - в гостевую
                if (i <= 11)
                {
                    homeTeam.AddPlayer(player);
                }
                else
                {
                    awayTeam.AddPlayer(player);
                }
            }

            // Начало игры
            game.Start();

            // Установка заголовка консоли
            Console.Title = "Футбольный матч";

            // Установка размеров окна консоли в соответствии с размерами стадиона
            Console.WindowWidth = stadium.Width + 2;
            Console.WindowHeight = stadium.Height + 3;

            // Цикл, в котором происходит обновление состояния игры и отрисовка поля
            while (true)
            {
                // Перемещение игроков и мяча на поле
                game.Move();

                // Отрисовка поля с игроками и мячом
                functions.DrawField(stadium.Width, stadium.Height, homeTeam.Players, awayTeam.Players, game.Ball);

                // Задержка для создания эффекта анимации
                Thread.Sleep(100);

                // Возврат курсора в начало консоли для обновления отображения
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}

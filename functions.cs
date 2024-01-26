using Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    internal class functions
    {
        // Класс для отображения футбольного поля и игровых элементов

        // Метод для отображения поля с игровыми элементами
        public static void DrawField(int width, int height, List<Player> homePlayers, List<Player> awayPlayers, Ball ball)
        {
            char borderSymbol = '#'; // Символ для отображения границы поля
            char homePlayerSymbol = '1'; // Символ для отображения домашних игроков
            char awayPlayerSymbol = '2'; // Символ для отображения гостевых игроков
            char ballSymbol = 'o'; // Символ для отображения мяча

            // Отрисовка границ поля
            DrawBorders(width, height, borderSymbol);
            // Отрисовка игроков домашней команды
            DrawPlayers(width, height, homePlayers, homePlayerSymbol);
            // Отрисовка игроков гостевой команды
            DrawPlayers(width, height, awayPlayers, awayPlayerSymbol);
            // Отрисовка мяча
            DrawBall(width, height, ball, ballSymbol);
        }

        // Метод для отображения границ поля
        private static void DrawBorders(int width, int height, char borderSymbol)
        {
            // Отрисовка вертикальных границ
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y + 1);
                Console.Write(borderSymbol);
                for (int x = 1; x < width - 1; x++)
                {
                    Console.Write(" ");
                }
                Console.Write(borderSymbol);
            }

            // Отрисовка верхней горизонтальной границы
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < width; i++)
            {
                Console.Write(borderSymbol);
            }

            // Отрисовка нижней горизонтальной границы
            Console.SetCursorPosition(0, height + 1);
            for (int i = 0; i < width; i++)
            {
                Console.Write(borderSymbol);
            }
        }

        // Метод для отображения игроков
        private static void DrawPlayers(int width, int height, List<Player> players, char playerSymbol)
        {
            // Проход по всем игрокам
            foreach (var player in players)
            {
                int x = (int)Math.Round(player.X);
                int y = (int)Math.Round(player.Y);

                // Проверка, что игрок находится в пределах поля
                if (x > 0 && x < width - 1 && y > 0 && y < height)
                {
                    Console.SetCursorPosition(x, y);
                    // Установка цвета в зависимости от символа игрока
                    Console.ForegroundColor = playerSymbol == '1' ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(playerSymbol);
                    Console.ResetColor();
                }
            }
        }

        // Метод для отображения мяча
        private static void DrawBall(int width, int height, Ball ball, char ballSymbol)
        {
            int x = (int)Math.Round(ball.X);
            int y = (int)Math.Round(ball.Y);

            // Проверка, что мяч находится в пределах поля
            if (x > 0 && x < width - 1 && y > 0 && y < height)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(ballSymbol);
            }
        }
    }
}

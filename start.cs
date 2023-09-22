using Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    public class start
    {
        public static void Main()
        {
            Random rndX = new Random();
            Random rndY = new Random();
            Console.WriteLine("enter the name of the first team:");
            string name_T1 = Console.ReadLine();
            Team t1 = new Team(name_T1);
            for (int i = 0; i < 7; i++)
            {
                int Xcord = rndX.Next(1, 13);
                int Ycord = rndY.Next(1, 13);
                Console.WriteLine("enter the name of the player in the first team:");
                string player_name_t1 = Console.ReadLine();
                Player p = new Player(player_name_t1, Xcord, Ycord, t1);
                t1.AddPlayer(p);
            }


            Console.WriteLine("enter the name of the second team:");
            string name_T2 = Console.ReadLine();
            Team t2 = new Team(name_T2);
            for (int i = 0; i < 7; i++)
            {
                int Xcord = rndX.Next(1, 13);
                int Ycord = rndY.Next(1, 13);
                Console.WriteLine("enter the name of the player in the second team:");
                string player_name_t2 = Console.ReadLine();
                Player p = new Player(player_name_t2, Xcord, Ycord, t2);
                t2.AddPlayer(p);
            }

            Stadium s = new Stadium(400, 300);

            Game g = new Game(t1, t2, s);
            g.Start();
        }
    }
}

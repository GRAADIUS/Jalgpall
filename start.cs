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
            Team t1 = new Team("Uno");
            Player p1_1 = new Player("Bruno", 2, 23, t1);
            Player p2_1 = new Player("Bruno", 2, 23, t1);
            Player p3_1 = new Player("Bruno", 2, 23, t1);
            Player p4_1 = new Player("Bruno", 2, 23, t1);
            Player p5_1 = new Player("Bruno", 2, 23, t1);
            Player p6_1 = new Player("Bruno", 2, 23, t1);
            Player p7_1 = new Player("Bruno", 2, 23, t1);
            t1.AddPlayer(p1_2);
            t1.AddPlayer(p2_2);
            t1.AddPlayer(p3_2);
            t1.AddPlayer(p4_2);
            t1.AddPlayer(p5_2);
            t1.AddPlayer(p6_2);
            t1.AddPlayer(p7_2);


            Team t2 = new Team("Dos");
            Player p1_2 = new Player("Barri", 2, 23, t2);
            Player p2_2 = new Player("Barri");
            Player p3_2 = new Player("Barri");
            Player p4_2 = new Player("Barri");
            Player p5_2 = new Player("Barri");
            Player p6_2 = new Player("Barri");
            Player p7_2 = new Player("Barri");
            t2.AddPlayer(p1_2);
            t2.AddPlayer(p2_2);
            t2.AddPlayer(p3_2);               
            t2.AddPlayer(p4_2);
            t2.AddPlayer(p5_2);
            t2.AddPlayer(p6_2);
            t2.AddPlayer(p7_2);

            Stadium s = new Stadium(400, 300);

            Game g = new Game(t1, t2, s);
            g.Start();
        }
    }
}

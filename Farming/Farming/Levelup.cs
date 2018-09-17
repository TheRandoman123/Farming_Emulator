using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming
{
    class Levelup
    {
        public static void LU(int lvl, int xp, int levelup, string topic)
        {
        levelup:
            Program.Clear();
            lvl++;
            xp = xp - levelup;
            levelup = (lvl * 3 / 2) * levelup;
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            Program.WL("");
            Console.WriteLine("LEVEL UP! You have just leveled up to level {0}", lvl);
            Program.WL("");
            Program.Write("Press enter to continue to the last menu...");
            Program.Read();

            if (xp >= levelup)
            {
                goto levelup;
            }

            switch (topic)
            {
                case "farm":
                    goto farm;
                case "buy":
                    goto buy;
                case "sell":
                    goto sell;
                case "menu":
                default:
                    goto menu;
            }
        }
    }
}

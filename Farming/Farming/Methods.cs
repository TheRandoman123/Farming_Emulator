using System;
using static Farming.Variables;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farming
{
    class Methods
    {
        #region CopyPasta
        /*
         * int bal, int xp, int lvl, int wseeds, int rseeds, int wbales, int rbales, int cans, int land, int waterings, int levelup, int wplanted, int rplanted, string user
         * 
         * bal, xp, lvl, wseeds, rseeds, wbales, rbales, cans, land, waterings, levelup, wplanted, rplanted, user
         */
        #endregion

        #region Clear()
        public static void Clear()
        {
            Console.Clear();
        }
        #endregion

        #region Read()
        public static void Read()
        {
            Console.ReadLine();
        }
        #endregion

        //#region RS
        //public static string RS = Console.ReadLine();
        //#endregion

        #region Write_for_string()
        public static void Write(string args)
        {
            Console.Write(args);
        }
        #endregion

        #region Write_Params()
        public static void Write(string format, params object[] arg)
        {
            Console.Write(format, arg[0], arg[1], arg[2], arg[3], arg[4], arg[5], arg[6], arg[7], arg[8], arg[9]);
        }
        #endregion

        #region WriteLine_for_string() 
        public static void WL(string args)
        {
            Console.WriteLine(args);
        }
        #endregion

//        #region WriteLine_Params()
//        public static void WL(string format, params object[] arg)
//        {
//            Console.WriteLine(format, arg);
//        }
//        #endregion

        #region TODO()
        public static void TODO()
        {
            WL("TODO...");
            Read();
        }
        #endregion

        #region Welcome()
        public static void Welcome()
        {
            Console.WriteLine("Welcome to Farming Emulator [v{0}]!", ver);
            Write("Please enter a username: ");
            user = Console.ReadLine();

            if (!(File.Exists(user + ".sav")))
            {
                NewPlayer();
            }
            else
            {
                OldPlayer();
            }
        }
        #endregion

        #region OldPlayer()
        public static void OldPlayer()
        {
            Clear();

            // Gets variables.
            TextReader tr = new StreamReader(user + ".sav");
            bal = Convert.ToInt32(tr.ReadLine());
            xp = Convert.ToInt32(tr.ReadLine());
            lvl = Convert.ToInt32(tr.ReadLine());
            wseeds = Convert.ToInt32(tr.ReadLine());
            rseeds = Convert.ToInt32(tr.ReadLine());
            wbales = Convert.ToInt32(tr.ReadLine());
            rbales = Convert.ToInt32(tr.ReadLine());
            cans = Convert.ToInt32(tr.ReadLine());
            land = Convert.ToInt32(tr.ReadLine());
            waterings = Convert.ToInt32(tr.ReadLine());
            levelup = Convert.ToInt32(tr.ReadLine());
            wplanted = Convert.ToInt32(tr.ReadLine());
            rplanted = Convert.ToInt32(tr.ReadLine());
            tr.Close();

            Console.WriteLine("Welcome back, {0}!", user);
            WL("");
            WL("-- Current Stats --");
            Console.WriteLine("Balance: ${0}", bal);
            Console.WriteLine("Level: {0}", lvl);
            Console.WriteLine("Experience: {0}", xp);
            Console.WriteLine("Land Owned: {0} acre(s)", land);
            Write("Press enter to continue...");
            Read();
            Menu();

        }
        #endregion

        #region NewPlayer()
        public static void NewPlayer()
        {
            Clear();

            // Setup the player.
            bal = 1200;
            xp = 0;
            lvl = 0;
            wseeds = 0;
            rseeds = 0;
            wbales = 0;
            rbales = 0;
            cans = 0;
            land = 1;
            waterings = 0;
            levelup = 100;
            wplanted = 0;
            rplanted = 0;

            // Save to file.
            TextWriter tw = new StreamWriter(user + ".sav");
            tw.WriteLine(bal);
            tw.WriteLine(xp);
            tw.WriteLine(lvl);
            tw.WriteLine(wseeds);
            tw.WriteLine(rseeds);
            tw.WriteLine(wbales);
            tw.WriteLine(rbales);
            tw.WriteLine(cans);
            tw.WriteLine(land);
            tw.WriteLine(waterings);
            tw.WriteLine(levelup);
            tw.WriteLine(wplanted);
            tw.WriteLine(rplanted);
            tw.Close();

            Console.WriteLine("Welcome, {0}!", user);
            WL("");
            WL("-- How to play --");
            WL("Progress through the game by entering options.");
            WL("Your goal is to gain as much money as possible.");
            WL("");
            WL("-- Starting --");
            WL("Balance: $1200");
            WL("Level: 0");
            WL("Experience: 0");
            WL("Land Owned: 1 acre");
            WL("");
            Write("Good luck!");
            Read();
            Menu();
        }
        #endregion

        #region Menu()
        public static void Menu()
        {
            topic = "menu";
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            WL("-- Main Menu --");
            WL("> Save and quit: type 'quit'");
            WL("> Go to the market to sell: type 'sell'");
            WL("> Go to the market to buy: type 'buy'");
            WL("> Go to your farm: type 'farm'");
            WL("");
            Write("My choice: ");
            string ch = Console.ReadLine();

            if (ch == "quit")
            {
                Quit();
            }
            else if (ch == "sell")
            {
                Sell();
            }
            else if (ch == "buy")
            {
                Buy();
            }
            else if (ch == "farm")
            {
                Farm();
            }
            else
            {
                WL("Sorry, but that is not an option.");
                Write("Press enter to continue to the menu...");
                Read();
                Menu();
            }
        }
        #endregion

        #region Sell()
        public static void Sell()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            WL("-- Sell Menu --");
            Console.WriteLine("Land         | 1 acre for $75 | Type 'land'  | You have: {0}", land);
            Console.WriteLine("Watering Can | 1 can for $30  | Type 'can'   | You have: {0}", cans);
            Console.WriteLine("Wheat Seeds  | 5 seeds for $3 | Type 'wheat' | You have: {0}", wseeds);
            Console.WriteLine("Rice Seeds   | 5 seeds for $7 | Type 'rice'  | You have: {0}", rseeds);
            Console.WriteLine("Wheat Bale   | 1 bale for $10 | Type 'wbale' | You have: {0}", wbales);
            Console.WriteLine("Rice Bale    | 1 bale for $20 | Type 'rbale' | You have: {0}", rbales);
            WL("");
            WL("Type 'back' to return to the main menu...");
            WL("");
            Write("My choice: ");
            string sell = Console.ReadLine();

            switch (sell)
            {
                case "land":
                    Sland();
                    break;
                case "can":
                    Scan();
                    break;
                case "wheat":
                    Swheat();
                    break;
                case "rice":
                    Srice();
                    break;
                case "wbale":
                    Swbale();
                    break;
                case "rbale":
                    Srbale();
                    break;
                case "back":
                    Menu();
                    break;
                default:
                    WL("Sorry, but you input something wrong... Hit enter to try again...");
                    Read();
                    Sell();
                    break;
            }

        }
        #endregion

        #region Sland()
        public static void Sland()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (land > 0)
            {
                bal = bal + 75;
                land--;
                xp = xp + 5;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the sell menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Sell();
            }
            else
            {
                WL("Store Keeper: You don't have enough to sell of that...");
                Write("Press enter to return to the sell menu...");
                Read();
                Sell();
            }

        }
        #endregion

        #region Scan()
        public static void Scan()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (cans > 0)
            {
                bal = bal + 30;
                cans--;
                xp = xp + 3;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the sell menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Sell();
            }
            else
            {
                WL("Store Keeper: You don't have enough to sell of that...");
                Write("Press enter to return to the sell menu...");
                Read();
                Sell();
            }
        }
        #endregion

        #region Swheat()
        public static void Swheat()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (wseeds > 0)
            {
                bal = bal + 3;
                wseeds = wseeds - 5;
                xp = xp + 1;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the sell menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Sell();
            }
            else
            {
                WL("Store Keeper: You don't have enough to sell of that...");
                Write("Press enter to return to the sell menu...");
                Read();
                Sell();
            }
        }
        #endregion

        #region Srice()
        public static void Srice()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (wbales > 0)
            {
                bal = bal + 7;
                rseeds--;
                xp = xp + 2;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the sell menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Sell();
            }
            else
            {
                WL("Store Keeper: You don't have enough to sell of that...");
                Write("Press enter to return to the sell menu...");
                Read();
                Sell();
            }
        }
        #endregion

        #region Swbale()
        public static void Swbale()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (wbales > 0)
            {
                bal = bal + 10;
                wbales--;
                xp = xp + 3;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the sell menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Sell();
            }
            else
            {
                WL("Store Keeper: You don't have enough to sell of that...");
                Write("Press enter to return to the sell menu...");
                Read();
                Sell();
            }
        }
        #endregion

        #region Srbale()
        public static void Srbale()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (rbales > 0)
            {
                bal = bal + 20;
                rbales--;
                xp = xp + 4;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the sell menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Sell();
            }
            else
            {
                WL("Store Keeper: You don't have enough to sell of that...");
                Write("Press enter to return to the sell menu...");
                Read();
                Sell();
            }
        }
        #endregion

        #region Buy()
        public static void Buy()
        {
            topic = "buy";
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            WL("-- Buy Menu --");
            Console.WriteLine("Land         | 1 acre for $100 | Type 'land'  | You have: {0}", land);
            Console.WriteLine("Watering Can | 1 can for $50   | Type 'can'   | You have: {0}", cans);
            Console.WriteLine("Wheat Seeds  | 5 seeds for $5  | Type 'wheat' | You have: {0}", wseeds);
            Console.WriteLine("Rice Seeds   | 5 seeds for $10 | Type 'rice'  | You have: {0}", rseeds);
            WL("");
            WL("Type 'back' to return to the main menu...");
            WL("");
            Write("My choice: ");
            string buy = Console.ReadLine();

            switch (buy)
            {
                case "land":
                    Bland();
                    break;
                case "can":
                    Bcan();
                    break;
                case "wheat":
                    Bwheat();
                    break;
                case "rice":
                    Brice();
                    break;
                case "back":
                    Menu();
                    break;
                default:
                    WL("Sorry, but you input something wrong... Hit enter to try again...");
                    Read();
                    Buy();
                    break;
            }
        }
        #endregion

        #region Bland()
        public static void Bland()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (bal >= 100)
            {
                bal = bal - 100;
                land++;
                xp = xp + 5;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the buy menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Buy();
            }
            else
            {
                WL("Store Keeper: Put that down! You don't have enough to buy that...");
                Write("Press enter to return to the buy menu...");
                Read();
                Buy();
            }

        }

        #endregion

        #region Bcan()
        public static void Bcan()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (bal >= 50)
            {
                bal = bal - 50;
                cans++;
                xp = xp + 3;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the buy menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
               Buy();
            }
            else
            {
                WL("Store Keeper: Put that down! You don't have enough to buy that...");
                Write("Press enter to return to the buy menu...");
                Read();
                Buy();
            }

        }

        #endregion

        #region Bwheat()
        public static void Bwheat()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (bal >= 5)
            {
                bal = bal - 5;
                wseeds = wseeds + 5;
                xp = xp + 2;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the buy menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Buy();
            }
            else
            {
                WL("Store Keeper: Put that down! You don't have enough to buy that...");
                Write("Press enter to return to the buy menu...");
                Read();
                Buy();
            }
        }
        #endregion

        #region Brice()
        public static void Brice()
        {
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            if (bal >= 10)
            {
                bal = bal - 10;
                rseeds = rseeds + 5;
                xp = xp + 2;
                WL("Store Keeper: Thank you for shopping!");
                Write("Press enter to return to the buy menu...");
                Read();
                if (xp >= levelup)
                {
                    Levelup();
                }
                Buy();
            }
            else
            {
                WL("Store Keeper: Put that down! You don't have enough to buy that...");
                Write("Press enter to return to the buy menu...");
                Read();
                Buy();
            }
        }
        #endregion

        #region Farm()
        public static void Farm()
        {
            topic = "farm";
            Clear();
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            WL("-- Farm Menu --");
            WL("> Plant crops: type 'plant'.");
            WL("> Water crops: type 'water'.");
            WL("> Harvest crops: type 'harvest'.");
            WL("");
            WL("> Go to main menu: type 'back'");
            WL("");
            Write("My choice: ");
            string farm = Console.ReadLine();

            switch (farm)
            {
                case "plant":
                    Plant();
                    break;
                case "water":
                    Water();
                    break;
                case "harvest":
                    Harvest();
                    break;
                case "back":
                    Menu();
                    break;
                default:
                    WL("Sorry, but you input something wrong... Hit enter to try again...");
                    Read();
                    Farm();
                    break;
            }
        }
        #endregion

        #region Plant()
        public static void Plant()
        {
            planted = wplanted + rplanted;
            space = land - planted;
            if (space > 0)
            {
                Clear();
                Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
                WL("");
                WL("-- Plant Menu --");
                Console.WriteLine("Crops planted: {0}", planted);
                Console.WriteLine("Space left: {0}", space);
                Console.WriteLine("Times watered: {0}", waterings);
                WL("");
                WL("> Plant wheat: type 'wheat'.");
                WL("> Plant rice: type 'rice'.");
                WL("");
                WL("> Go back to farm menu: type 'back'.");
                WL("");
                WL("WARNING: If you plant crops, you will lose all the times that you watered.");
                WL("");
                Write("My choice: ");
                string plant = Console.ReadLine();

                switch (plant)
                {
                    case "wheat":
                        if (wseeds > 0)
                        {
                            wseeds--;
                            wplanted++;
                            waterings = 0;
                            xp = xp + 2;
                            WL("");
                            WL("The Land: Successfully planted a wheat seed!");
                            Write("Press enter to return to the plant menu...");
                            Read();
                            Plant();
                        }
                        else
                        {
                            WL("The Land: Sorry, but you don't have any of that... Hmm...");
                            Write("Press enter to return to the plant menu...");
                            Read();
                            Plant();
                        }
                        break;
                    case "rice":
                        if (rseeds > 0)
                        {
                            rseeds--;
                            rplanted++;
                            waterings = 0;
                            xp = xp + 2;
                            WL("");
                            WL("The Land: Successfully planted a rice seed!");
                            Write("Press enter to return to the plant menu...");
                            Read();
                            Plant();
                        }
                        else
                        {
                            WL("The Land: Sorry, but you don't have any of that... Hmm...");
                            Write("Press enter to return to the plant menu...");
                            Read();
                            Plant();
                        }
                        break;
                    case "back":
                        Farm();
                        break;
                    default:
                        WL("Sorry, but you input something wrong... Hit enter to try again...");
                        Read();
                        Plant();
                        break;
                }
            }
            else
            {
                WL("The Land: Sorry, but you don't have any space left... Hmm...");
                Write("Press enter to return to the farm menu...");
                Read();
                Farm();
            }
        }
        #endregion

        #region Water()
        public static void Water()
        {
            planted = wplanted + rplanted;
            space = land - planted;
            if (waterings < 3)
            {
                Clear();
                Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
                WL("");
                WL("-- Water Menu --");
                Console.WriteLine("Times watered: {0}", waterings);
                WL("");
                WL("> Water all crops: type 'water'.");
                WL("");
                WL("> Go back to farm menu: type 'back'.");
                WL("");
                string water = Console.ReadLine();

                switch (water)
                {
                    case "water":
                        if (cans > 0)
                        {
                            cans--;
                            xp = xp + 10;
                            waterings++;
                            WL("The Land: Successfully watered all the crops!");
                            Write("Press enter to return to the water menu...");

                            if (xp >= levelup)
                            {
                                Levelup();
                            }

                            Water();
                        }
                        else
                        {
                            WL("The Land: Sorry, but you don't have any of that... Hmm...");
                            Write("Press enter to return to the water menu...");
                            Read();
                            Water();
                        }
                        break;
                    case "back":
                        Farm();
                        break;
                    default:
                        Write("Sorry, but you input something wrong... Hit enter to try again...");
                        Read();
                        Water();
                        break;
                }
            }
            else
            {
                Clear();
                Write("Harvest is ready! Hit enter to harvest...");
                Read();
                Harvest();
            }
        }
        #endregion

        #region Harvest()
        public static void Harvest()
        {
            planted = wplanted + rplanted;
            space = land - planted;
            if (waterings >= 3)
            {
                Clear();
                Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
                WL("");
                WL("-- Harvest Menu --");
                Console.WriteLine("Crops planted: {0}", planted);
                Console.WriteLine("Space left: {0}", space);
                Console.WriteLine("Times watered: {0}", waterings);
                WL("");
                WL("> Harvest your crops: type 'harvest'.");
                WL("");
                WL("> Go back to the farm menu: type 'back'.");
                WL("");
                Write("My choice: ");
                string harv = Console.ReadLine();

                switch (harv)
                {
                    case "harvest":
                        wbales = wbales + wplanted;
                        rbales = rbales + rplanted;
                        wplanted = 0;
                        rplanted = 0;
                        xp = xp + 7;
                        WL("");
                        WL("The Land: Successfully harvested all crops!");
                        Write("Press enter to return to the farm menu...");

                        if (xp >= levelup)
                        {
                            Levelup();
                        }
                        Farm();
                        break;
                    case "back":
                        Farm();
                        break;
                    default:
                        Write("Sorry, but you input something wrong... Hit enter to try again...");
                        Read();
                        Harvest();
                        break;
                }
            }
			else
			{
                Clear();
                WL("Sorry, but the havest is not ready yet...");
                Write("Press enter to return to the farm menu...");
                Read();
                Farm();
            }
        }
        #endregion

        #region Levelup()
        public static void Levelup()
        {
            Clear();
            lvl++;
            xp = xp - levelup;
            levelup = (lvl * 3 / 2) * levelup;
            Console.WriteLine("-- Username: {0} - Balance: {1} - Level: {2} - Experience: {3} - Acres Owned: {4}", user, bal, lvl, xp, land);
            WL("");
            Console.WriteLine("LEVEL UP! You have just leveled up to level {0}", lvl);
            WL("");
            Write("Press enter to continue to the last menu...");
            Read();

            if (xp >= levelup)
            {
                Levelup();
            }

            switch (topic)
            {
                case "farm":
                    Farm();
                    break;
                case "buy":
                    Buy();
                    break;
                case "sell":
                    Sell();
                    break;
                case "menu":
                default:
                    Menu();
                    break;
            }
        }
        #endregion

        #region Quit()
        public static void Quit()
        {
            Clear();
            WL("Thank you for playing!");
            Write("Press enter to save and quit...");
            Read();
            TextWriter save = new StreamWriter(user + ".sav");
            save.WriteLine(bal);
            save.WriteLine(xp);
            save.WriteLine(lvl);
            save.WriteLine(wseeds);
            save.WriteLine(rseeds);
            save.WriteLine(wbales);
            save.WriteLine(rbales);
            save.WriteLine(cans);
            save.WriteLine(land);
            save.WriteLine(waterings);
            save.WriteLine(levelup);
            save.WriteLine(wplanted);
            save.WriteLine(rplanted);
            save.Close();
            return;
        }
        #endregion
    }
}

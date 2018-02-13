using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    class GameSet
    {
        public static int ActiveMenu = 1, GameMode = 1;
        private static bool PlayerOn;
        private static int Wave = 1;
        private static Random rdn = new Random();
        public static float delta = 100;
        private static int x = 2, y = 8;
        private static int lowLimit = 1000;
        private static int highLimit = 10000;
        private static int BossCount = 0;
        public static bool FinalWave = false;
        public static void Menu()
        {

            switch (ActiveMenu)
            {
                case 1:
                    {
                        FinalWave = false;
                        MainMenu.Draw(Program.window);
                        MainMenu.ActiveMenu();
                        PlayerOn = false;
                        LoseMenu.On = false;
                        LoseMenu.isActive();
                        break;
                    }
                case 2:
                    {
                        Score.Draw(Program.window);
                        if (!PlayerOn)
                        {
                            PlayerOn = true;
                            Program.world.AddObject(new Player());
                            Program.world.AddObject(new PlayerLife());
                            CreateEnemyShips(x, y, 100, 0);
                            if (y < 21)
                            {
                                y+=x;
                                if (y == 20)
                                {
                                    y = 8;
                                    x++;
                                }
                                if (x == 5)
                                    x = 2;
                            }
                            Wave++;

                        }
                        if (Program.world.AllDestroyed() && FinalWave)
                        {
                            ActiveMenu = 5;
                        }
                        else if (Program.world.AllDestroyed())
                            switch (Wave % 6)
                            {
                                case 0:
                                    {
                                        Wave++;
                                        if (BossCount == 5)
                                        {
                                            Program.world.AddObject(new FinalBoss());
                                            FinalWave = true;
                                            CreateEnemyShips(x, y, 100, 0);
                                            if (y < 21)
                                            {
                                                y += x;
                                                if (y == 20)
                                                {
                                                    y = 8;
                                                    x++;
                                                }
                                                if (x == 5)
                                                    x = 2;
                                            }
                                        }
                                        else
                                        {
                                            Program.world.AddObject(new Boss());
                                        }
                                        BossCount++;
                                        break;
                                    }
                                case 1:
                                    {
                                        Wave++;
                                        CreateEnemyShips(x, y, 100, 0);
                                        if (lowLimit > 100)
                                            lowLimit -= 10;
                                        if (highLimit > 1000)
                                            highLimit -= 300;
                                        if (y < 21)
                                        {
                                            y += x;
                                            if (y == 20)
                                            {
                                                y = 8;
                                                x++;
                                            }
                                            if (x == 5)
                                                x = 2;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        Wave++;
                                        CreateEnemyShips(x, y, 100, 0);
                                        if (y < 21)
                                        {
                                            y+=x;
                                            if (y == 20)
                                            {
                                                y = 8;
                                                x++;
                                            }
                                            if (x == 5)
                                                x = 2;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Wave++;
                                        CreateEnemyShips(x, y, 100, 0);
                                        if (y < 21)
                                        {
                                            y += x;
                                            if (y == 20)
                                            {
                                                y = 8;
                                                x++;
                                            }
                                            if (x == 5)
                                                x = 2;
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        Wave++;
                                        CreateEnemyShips(x, y, 100, 0);
                                        if (y < 21)
                                        {
                                            y += x;
                                            if (y == 20)
                                            {
                                                y = 8;
                                                x++;
                                            }
                                            if (x == 5)
                                                x = 2;
                                        }
                                        break;
                                    }
                                case 5:
                                    {
                                        Wave++;
                                        CreateEnemyShips(x, y, 100, 0);
                                        if (y < 21)
                                        {
                                            y += x;
                                            if (y == 20)
                                            {
                                                y = 8;
                                                x++;
                                            }
                                            if (x == 5)
                                                x = 2;
                                        }
                                        break;
                                    }
                                default:
                                    break;

                            }
                        break;
                    }
                case 3:
                    {
                        Program.world.EndGame();
                        LoseMenu.update();
                        LoseMenu.Draw(Program.window);
                        LoseMenu.On = true;
                        LoseMenu.isActive();
                        break;
                    }
                case 4:
                    {
                        AboutMenu.Draw(Program.window);
                        break;
                    }
                case 5:
                    {
                        Program.world.EndGame();
                        Victory.Draw(Program.window);
                        break;
                    }
                default:
                    break;
            }
        }
        public static void CreateEnemyShips(int xSize, int ySize, float xPoz, float yPoz)
        {

            float copy = xPoz;
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    Program.world.AddObject(new EnemyShip(new Vector2f(xPoz += 40, yPoz)) { cooldown = rdn.Next(lowLimit, highLimit) });
                }
                yPoz -= 40;
                xPoz = copy;
            }
        }
    }
}

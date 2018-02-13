using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
namespace Template
{
    class Resources
    {
        public static List<Texture> Texture = new List<Texture>();
        public static Dictionary<string, IntRect> TextureRects;
        public static Texture menuItem;
        public static Font font;
        public static Dictionary<String, Texture> Bosses;
        public static Dictionary<String, Texture> LifeBar;
        public static Texture bonus;
        public static void LoadResources()
        {
            bonus = new SFML.Graphics.Texture("Resources/sphere.png");
            LifeBar = new Dictionary<string, Texture>();
            LifeBar.Add("0", new SFML.Graphics.Texture("Resources/0.png"));
            LifeBar.Add("1", new SFML.Graphics.Texture("Resources/1.png"));
            LifeBar.Add("2", new SFML.Graphics.Texture("Resources/2.png"));
            LifeBar.Add("3", new SFML.Graphics.Texture("Resources/3.png"));
            LifeBar.Add("4", new SFML.Graphics.Texture("Resources/4.png"));
            LifeBar.Add("5", new SFML.Graphics.Texture("Resources/5.png"));
            LifeBar.Add("6", new SFML.Graphics.Texture("Resources/6.png"));
            LifeBar.Add("7", new SFML.Graphics.Texture("Resources/7.png"));
            LifeBar.Add("8", new SFML.Graphics.Texture("Resources/8.png"));
            LifeBar.Add("9", new SFML.Graphics.Texture("Resources/9.png"));
            LifeBar.Add("Full", new SFML.Graphics.Texture("Resources/Full.png"));
            Bosses = new Dictionary<String, Texture>();
            Bosses.Add("Boss1", new SFML.Graphics.Texture("Resources/Boss1.png"));
            Bosses.Add("Boss2", new SFML.Graphics.Texture("Resources/Boss2.png"));
            Bosses.Add("Boss3", new SFML.Graphics.Texture("Resources/Boss3.png"));
            Bosses.Add("Boss4", new SFML.Graphics.Texture("Resources/Boss4.png"));
            Bosses.Add("Boss5", new SFML.Graphics.Texture("Resources/Boss5.png"));
            Texture = new List<SFML.Graphics.Texture>();
            Texture.Add(new Texture("Resources/Crux_(Southern_Cross)_from_Hobart,_Tasmania.jpg"));
            Texture.Add(new SFML.Graphics.Texture(new SFML.Graphics.Texture("Resources/Spaceship.png")));
            Texture.Add(new Texture("Resources/BackGround.png"));
            Texture.Add(new SFML.Graphics.Texture("Resources/EnemySpaceShip.png"));
            menuItem = new Texture("Resources/Menu1.png");
            font = new Font("Resources/Gravity-Regular.otf");
            TextureRects = new Dictionary<string, IntRect>()
            {
                ["missile1"] = new IntRect(448, 419, 6, 10),
                ["RoundButtonUnpressed_444"] = new IntRect(514, 514, 128, 128),
                ["BG"] = new IntRect(0, 0, 600, 418),
                ["Untitled"] = new IntRect(387, 419, 60, 70),
            };
            MainMenu.LoadMenuResources();
            MainMenu.CreateMenu();
            LoseMenu.LoadResources();
            LoseMenu.CreateMenu();
            AboutMenu.Init();
            AboutMenu.CreateMenu();
            Victory.Init();
            Victory.Show();


        }
    }
}

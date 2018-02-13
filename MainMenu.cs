using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using System.Diagnostics;
using SFML.System;

namespace Template
{
    class MainMenu
    {
        public static Stopwatch watch = new Stopwatch();
        
        public static float SizeX = Resources.TextureRects["BG"].Width;
        public static float SizeY = Resources.TextureRects["BG"].Height;
        public static float buttonsize = 61;
        public static Text text = new Text();
        public static List<Sprite> MenuItems = new List<Sprite>();
        public static List<Text> menuinfo = new List<Text>();
        public static void LoadMenuResources()
        {
            
            menuinfo.Add(new Text("Space Invader", Resources.font, 20));
            menuinfo.Add(new Text("Start Game", Resources.font, 20));
            menuinfo.Add(new Text("God Mode", Resources.font, 20));
            menuinfo.Add(new Text("About", Resources.font, 20));
            menuinfo.Add(new Text("Exit", Resources.font, 20));
            MenuItems.Add(new Sprite(Resources.Texture[2], new IntRect(0, 0, 600, 418)));
            MenuItems.Add(new Sprite(Resources.menuItem));
            MenuItems.Add(new Sprite(Resources.menuItem));
            MenuItems.Add(new Sprite(Resources.menuItem));
            MenuItems.Add(new Sprite(Resources.menuItem));
        }


         public static void CreateMenu()
        {
            
            MenuItems[0].Position = new SFML.System.Vector2f(100, 50);
            menuinfo[0].CharacterSize = 35;
            menuinfo[0].Position = new Vector2f(MenuItems[0].Position.X  + 170, MenuItems[0].Position.Y + 20);
            for (int i = 1; i < MenuItems.Count(); i++)
            {
                MenuItems[i].Position = new Vector2f(SizeX / 3 + buttonsize / 2, (i + 3 / 2) * buttonsize);
                MenuItems[i].Scale = new Vector2f(1f, 0.6f);
                menuinfo[i].Position = new Vector2f(MenuItems[i].Position.X, MenuItems[i].Position.Y + 5);
                menuinfo[i].Color = new Color(Color.White);
            }

        }

        private static void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            //GameSet.ActiveMenu = 1;
        }

        private static void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {

            if(MenuItems[1].GetGlobalBounds().Contains(Mouse.GetPosition().X - Program.window.Position.X, Mouse.GetPosition().Y - 31 - Program.window.Position.Y))
            {
                GameSet.ActiveMenu = 2;
                Program.window.MouseButtonPressed -= Window_MouseButtonPressed;
                Program.window.MouseButtonReleased -= Window_MouseButtonReleased;
                GameSet.GameMode = 1; 
            }
            else
            if (MenuItems[4].GetGlobalBounds().Contains(Mouse.GetPosition().X - Program.window.Position.X, Mouse.GetPosition().Y - 31 - Program.window.Position.Y))
                Program.window.Close();
            else
            if (MenuItems[3].GetGlobalBounds().Contains(Mouse.GetPosition(Program.window).X, Mouse.GetPosition(Program.window).Y))
            {
                GameSet.ActiveMenu = 4;
                Program.window.MouseButtonPressed -= Window_MouseButtonPressed;
                Program.window.MouseButtonReleased -= Window_MouseButtonReleased;
            }
            if (MenuItems[2].GetGlobalBounds().Contains(Mouse.GetPosition(Program.window).X, Mouse.GetPosition(Program.window).Y))
            {
                GameSet.ActiveMenu = 2;
                GameSet.GameMode = 2;
                Program.window.MouseButtonPressed -= Window_MouseButtonPressed;
                Program.window.MouseButtonReleased -= Window_MouseButtonReleased;
            }
        }

        public static void Draw(RenderWindow window)
        {
            foreach (Sprite s in MenuItems)
                window.Draw(s);
            foreach (Text t in menuinfo)
                window.Draw(t);

        }
        public static void ActiveMenu()
        {
            if (GameSet.ActiveMenu == 1)
            {
                Program.window.MouseButtonPressed += Window_MouseButtonPressed;
                Program.window.MouseButtonReleased += Window_MouseButtonReleased;
            }

        }



    }
}

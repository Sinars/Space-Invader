using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
namespace Template
{
    class AboutMenu
    {
        private static Sprite About;
        private static Text text;
        private static Text CloseText;
        private static Sprite close;
        public static void Init()
        {
            About = new Sprite();
            text = new Text();
            close = new Sprite();
            CloseText = new Text();
            About.Texture = Resources.Texture[2];
            About.TextureRect = new IntRect(0, 0, 600, 418);
            close.Texture = Resources.menuItem;
            CloseText.Font = Resources.font;
            text.Font = Resources.font;
            Program.window.MouseButtonPressed += Window_MouseButtonPressed;
        }

        private static void Window_MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            if (close.GetGlobalBounds().Contains(Mouse.GetPosition(Program.window).X, Mouse.GetPosition(Program.window).Y))
                GameSet.ActiveMenu = 1;
            Program.window.MouseButtonPressed -= Window_MouseButtonPressed;
        }

        public static void CreateMenu()
        {
            About.Position = new SFML.System.Vector2f(100, 50);
            text.DisplayedString = "Space Invader, shoot your way through\n the waves of alien ships\n How long can you survive?";
            text.Position = new SFML.System.Vector2f(2 * About.Position.X, 4 * About.Position.Y);
            text.Color = new Color(Color.White);
            text.CharacterSize = 20;
            close.Position = new SFML.System.Vector2f(3 * About.Position.X, 7 * About.Position.Y);
            close.Scale = new SFML.System.Vector2f(0.6f, 0.6f);
            CloseText.Position = new SFML.System.Vector2f(close.Position.X + 90, close.Position.Y + 5);
            CloseText.DisplayedString = "OK";
            CloseText.CharacterSize = 20;
        }
        public static void Draw(RenderWindow Window)
        {
            About.Draw(Window, RenderStates.Default);
            text.Draw(Window, RenderStates.Default);
            close.Draw(Window, RenderStates.Default);
            CloseText.Draw(Window, RenderStates.Default);
        }
        public static void Disable()
        {

        }
    }
}

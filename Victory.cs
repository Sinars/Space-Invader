using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
namespace Template
{
    class Victory
    {
        private static Sprite Menu;
        private static Sprite Button;
        private static Text Won;
        private static Text okButton;
        private static Text score = new Text();
        public static void Init()
        {
            Menu = new Sprite();
            Button = new Sprite();
            Won = new Text();
            okButton = new Text();
            Menu.Texture = Resources.Texture[2];
            Menu.TextureRect = new IntRect(0, 0, 600, 418);
            score.Font = Resources.font;
            Button.Texture = Resources.menuItem;
            Won.Font = Resources.font;
            okButton.Font = Resources.font;
            Program.window.MouseButtonPressed += Window_MouseButtonPressed;
            
    }

        private static void Window_MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            if (Button.GetGlobalBounds().Contains(Mouse.GetPosition(Program.window).X, Mouse.GetPosition(Program.window).Y))
                GameSet.ActiveMenu = 1;
           
        }

        public static void Show()
        {
            Menu.Position = new SFML.System.Vector2f(100, 50);
            Won.DisplayedString = "Congratulations, you've survived through\n                        all the waves";
            Won.Position = new SFML.System.Vector2f(7.0f/4.0f * Menu.Position.X, 4 * Menu.Position.Y);
            Won.Color = new Color(Color.White);
            Won.CharacterSize = 25;
            Button.Position = new SFML.System.Vector2f(3 * Menu.Position.X, 7 * Menu.Position.Y);
            Button.Scale = new SFML.System.Vector2f(0.6f, 0.6f);
            okButton.Position = new SFML.System.Vector2f(Button.Position.X + 90, Button.Position.Y + 5);
            okButton.DisplayedString = "OK";
            okButton.CharacterSize = 20;
        }

        public static void Draw(RenderWindow Window)
        {
            Menu.Draw(Window, RenderStates.Default);
            Won.Draw(Window, RenderStates.Default);
            Button.Draw(Window, RenderStates.Default);
            okButton.Draw(Window, RenderStates.Default);
        }

    }
}

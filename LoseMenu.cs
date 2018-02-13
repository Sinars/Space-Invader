using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Template
{
    class LoseMenu
    {
        private static Text Lose = new Text();
        private static Text score = new Text();
        private static Sprite Back = new Sprite();
        private static Sprite Hit = new Sprite();
        private static Text ok = new Text();
        public static bool On = true;
        private static float mouseX = Mouse.GetPosition().X - Program.window.Position.X;
        private static float mouseY = Mouse.GetPosition().Y - Program.window.Position.Y;
        public static void LoadResources()
        {
            Lose.Font = Resources.font;
            score.Font = Resources.font;
            ok.Font = Resources.font;
            Back.Texture = Resources.Texture[2];
            Back.TextureRect = Resources.TextureRects["BG"];
            Hit.Texture = Resources.menuItem;

        }

        public static void CreateMenu()
        {
            Lose.DisplayedString = "Game Lost";
            Lose.CharacterSize = 35;
            ok.DisplayedString = "OK";
            ok.Color = new Color(Color.White);
            ok.CharacterSize = 15;
            Lose.Color = new Color(Color.White);
            
            score.CharacterSize = 20;
            score.Color = new Color(Color.White);
            Back.Position = new SFML.System.Vector2f(150, 100);
            Lose.Position = new SFML.System.Vector2f(Back.Position.X + 100, Back.Position.Y + 20);
            score.Position = new SFML.System.Vector2f(Lose.Position.X - 50, Lose.Position.Y + 100);
            Back.Scale = new SFML.System.Vector2f(0.7f, 0.7f);
            Hit.Position = new SFML.System.Vector2f(score.Position.X + 100, Lose.Position.Y + 180);
            Hit.Scale = new SFML.System.Vector2f(0.3f, 0.5f);
            ok.Position = new SFML.System.Vector2f(Hit.Position.X + 35, Hit.Position.Y + 5);
            Program.window.MouseButtonPressed += Window_MouseButtonPressed;
        }
        public static void update()
        {
            score.DisplayedString = "You have scored: " + Score.score.ToString();
        }
        private static void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (Hit.GetGlobalBounds().Contains(Mouse.GetPosition().X - Program.window.Position.X, Mouse.GetPosition().Y - 25 - Program.window.Position.Y))
            {            
                GameSet.ActiveMenu = 1;
                LoseMenu.On = false;
            }
        }

        public static void Draw(RenderWindow window)
        {
            window.Draw(Back);
            window.Draw(Lose);
            window.Draw(score);
            window.Draw(Hit);
            window.Draw(ok);
        }
        public static void isActive()
        {
            if (On)
            { Program.window.MouseButtonPressed += Window_MouseButtonPressed; }
            else
                Program.window.MouseButtonPressed -= Window_MouseButtonPressed;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.System;
using SFML.Graphics;

namespace Template
{
    class Score
    {
        private static Text text;
        public static int score = 0;
        public static void init()
        {
            text = new Text();
            text.Font = Resources.font;
            text.Position = new Vector2f(10, 10);
            text.CharacterSize = 20;
        }
        public static void update()
        {
            text.DisplayedString =  ($"Score: {score.ToString()}");
            if (GameSet.ActiveMenu == 1)
                score = 0;
        }
        public static void Draw(RenderWindow window)
        {
            text.Draw(window, RenderStates.Default);
        }
    }
}

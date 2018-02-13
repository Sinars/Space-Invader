using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System.Threading;
using System.Diagnostics;

namespace Template
{
    class Program
    {

        public static RenderWindow window;
        public static World world = new World();
        public static ContextSettings settings;
        private static Image icon;
        public static void Main(string[] args)
        {
            //icon = new Image("Resources\\icon.png");
            settings.AntialiasingLevel = 0;
            window = new RenderWindow(new VideoMode(800, 480), "Space Invader", Styles.Default,settings);         
            Resources.LoadResources();
            //window.SetIcon(32, 32, icon.Pixels);
            Score.init();
            window.SetFramerateLimit(60);
            window.SetKeyRepeatEnabled(false);
            window.Closed += Window_Closed;
            
            world.AddObject(new Background());
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();
                world.Draw(window);
                world.update();
                Score.update();
                GameSet.Menu();
                window.Display();
            }          
        }
        

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
        

    }
}

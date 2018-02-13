using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Template
{
    class DropLife:Player
    {
        public float PositionX { get; set; }
        private bool Moving;
        private int Speed = 2;
        public float PositionY { get; set; }
        public override void Init()
        {
            this.Texture = new Texture("Resources/1.png");
            Moving = true;
            this.Scale = new SFML.System.Vector2f(0.2f, 0.2f);
            Position = new SFML.System.Vector2f(PositionX, PositionY);
        }

        
        public override void Update()
        {
            if (Moving)
                this.Position = new SFML.System.Vector2f(Position.X + Speed, PositionY++);
            else
                this.Position = new SFML.System.Vector2f(Position.X - Speed, PositionY++);
            if (Position.X >= 500)
                Moving = false;
            else
                if (Position.X <= 100)
                Moving = true;
            if (PositionY > 480)
             Destroy();

        }
        public override void Destroy()
        {
            base.Destroy();
            IsAlive = false;
        }
    }
}

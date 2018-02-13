using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    class TripleAttack:Player
    {
        private float y;
        private bool Moving;
        private int Speed = 2;
        private static Random rdn;
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public override void Init()
        {
            rdn = new Random();
            Moving = true;
            y = 0;
            this.Position = new SFML.System.Vector2f(PositionX, 0);
            this.Texture = new SFML.Graphics.Texture("Resources/rocket.png");
            this.Scale = new SFML.System.Vector2f(0.05f, 0.05f);
        }
        public override void Update()
        {
            if(Moving)
                this.Position = new SFML.System.Vector2f(Position.X + Speed, y++);
            else
                this.Position = new SFML.System.Vector2f(Position.X - Speed, y++);
            if (Position.X >= 500)
                Moving = false;
            else
                if (Position.X <= 100)
                Moving = true;
        }
    }
}

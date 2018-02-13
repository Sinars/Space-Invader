using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    class AttackSpeed : Player
    {
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        private bool Moving;
        private int Speed = 2;
        public override void Init()
        {
            Texture = Resources.bonus;
            Moving = true;
            Position = new SFML.System.Vector2f(PositionX, PositionY);
            Scale = new SFML.System.Vector2f(0.01f, 0.01f);
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
    }
}

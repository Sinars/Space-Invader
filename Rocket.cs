using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Template
{
    class Rocket : Object
    {
        Stopwatch s = new Stopwatch();
        public float Speed { get; set; }

        public bool PlayerSpawned { get; set; }
        private int Lifetime = 5000;
        public Rocket(Vector2f Position, float Rotation)
        {
            s.Start();
            this.Position = Position;
            RotationTarget = Rotation;
            Speed = 3;
        }
        public float RotationTarget
        {
            set
            {
                float angle = value / 180 * (float)Math.PI;
                dx = (float)Math.Cos(angle);
                dy = (float)Math.Sin(angle);
                Rotation = value + 90;
            }
        }

        private float dx, dy;
        public override void Init()
        {
            Texture = new SFML.Graphics.Texture("Resources/Rocket1.png");
            Scale = new Vector2f(0.2f, 0.2f);
        }

        public override void Update()
        {
            Position += new SFML.System.Vector2f(dx * Speed, dy * Speed);
            if (s.ElapsedMilliseconds > Lifetime)
                Destroy();
        }
        public override void Destroy()
        {
            IsAlive = false;
            base.Destroy();
        }
    }
}

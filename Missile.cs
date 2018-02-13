using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Template
{
    class Missile : Object
    {
        Stopwatch s = new Stopwatch();

        public Missile(Vector2f Position, float Rotation)
        {
            s.Start();
            this.Position = Position;
            RotationTarget = Rotation;
            Speed = 3;
        }
        public float Speed { get; set; }
        public bool PlayerSpawned { get; set; }
        public bool EnemySpawned { get; set; }
        private int Lifetime = 5000;
        public int Damage { get; set; }
        public bool BossSpawned { get; set; }
        public bool Final { get; set; }
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
            this.TextureRect = Resources.TextureRects["missile1"];
            this.Texture = Resources.Texture[2];

        }

        public override void Update()
        {
            Position += new SFML.System.Vector2f(dx * Speed, dy * Speed);
            if (s.ElapsedMilliseconds > Lifetime || Position.Y <= 30)
                Destroy();
        }


        public override void Destroy()
        {
            IsAlive = false;
            base.Destroy();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Template
{
    class FinalBoss : Object
    {
        private int Speed = 1;
        private int cooldown;
        private int y;
        private bool Moving;
        private int Life = 1000;
        private Stopwatch s = new Stopwatch();
        public override void Init()
        {
            s.Start();
            cooldown = 1000;
            Moving = true;
            Texture = new SFML.Graphics.Texture("Resources/Final.png");
            Scale = new SFML.System.Vector2f(0.1f, 0.1f);
            Position = new SFML.System.Vector2f(0, 0);
            Origin = new SFML.System.Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2);
            Collided += FinalBoss_Collided;
        }

        private void FinalBoss_Collided(Object ob)
        {
            if (ob is Missile && ((Missile)ob).PlayerSpawned)
            {
                ob.Destroy();
                Life--;
            }
            if (ob is Rocket && ((Rocket)ob).PlayerSpawned)
            {
                ob.Destroy();
                Life -= 3;
            }
        }

        public override void Update()
        {
            if (y < 80)
                Position = new SFML.System.Vector2f(Position.X + Speed, y++);
            if (Moving)
                Position = new SFML.System.Vector2f(Position.X + Speed, Position.Y);
            else
                Position = new SFML.System.Vector2f(Position.X - Speed, Position.Y);
            if (Position.X >= 600)
                Moving = false;
            else
                if (Position.X <= 100)
                Moving = true;
            if (s.ElapsedMilliseconds > cooldown)
            {
                s.Restart();
                World.AddObject(new Missile(Position, 90) { Speed = 3, Damage = 2, EnemySpawned = true });

            }
            if (Life < 0)
                Destroy();

        }
        public override void Destroy()
        {
           
            base.Destroy();
            Score.score += 1000;
            
        }
    }
}

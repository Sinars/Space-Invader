using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Template
{
    class EnemyShip : Object
    {
        public static int Damage = 1;
        public static int Count = 0;
        private float delta = 1;
        private Stopwatch s = new Stopwatch();
        private int lasthit;
        private int increment = 0;
        private static Random rdn;
        private float PositionX;
        private int life = 3;
        public int cooldown
        {
            get; set;
        }
        public EnemyShip(Vector2f position)
        {
            Position = position;
            Count++;
        }
        public override void Init()
        {
            rdn = new Random();
            s.Start();
            Texture = Resources.Texture[3];
            Scale = new Vector2f(0.3f, 0.3f);
            Origin = new Vector2f(Texture.Size.X / 2, Texture.Size.Y);
            lasthit = Environment.TickCount;
            Collided += EnemyShip_Collided;
            PositionX = Position.X;
        }
        public override void Update()
        {
            if (increment < 200)
            {
                Position = new Vector2f(Position.X, Position.Y + delta);
                increment++;
            }
             
            if (World.AllDestroyed())
                increment = 0;
            if (s.ElapsedMilliseconds > cooldown)
            {
                s.Restart();
                World.AddObject(new Missile(Position, 90) { Speed = 3, EnemySpawned = true });

            }


        }

        private void EnemyShip_Collided(Object ob)
        {
            if (ob is Missile && ((Missile)ob).PlayerSpawned)
            {
                Destroy();
                ob.Destroy();
                Score.score++;
            }
            if (ob is Rocket && ((Rocket)ob).PlayerSpawned)
            {
                Destroy();
                life--;
                if (life <= 0)
                    ob.Destroy();
                Score.score++;
                
            }
        }
        public override void Destroy()
        {
            if (rdn.Next(0, 100) == 1)
                World.AddObject(new TripleAttack() { PositionX = this.Position.X, PositionY = Position.Y });
            if (rdn.Next(0, 300) == 2)
                World.AddObject(new DropLife() { PositionX = this.Position.X, PositionY = Position.Y });
            if (rdn.Next(0, 50) == 3)
                World.AddObject(new AttackSpeed() { PositionX = this.Position.X, PositionY = Position.Y });
            base.Destroy();
       }

    }
}

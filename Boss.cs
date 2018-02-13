using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using System.Diagnostics;

namespace Template
{
    class Boss : Object
    {
        private int Damage { get; set; }
        private int Life = 100;
        private int speed = 1;
        private Stopwatch s = new Stopwatch();
        private float delta = -50;
        public static int Count;
        public static int BossCount = 0;
        private Dictionary<String, Texture> Bosses = new Dictionary<string, Texture>();
        private static Random rdn;
        private bool Moving;
        public Texture texture { get; set; }
        public override void Init()
        {
            Moving = true;
            rdn = new Random(); 
            BossCount++;
            if (BossCount > 5)
                BossCount = 1;
            s.Start();
            Bosses.Add("Boss1", new Texture("Resources/Boss1.png"));
            Bosses.Add("Boss2", new Texture("Resources/Boss2.png"));
            Bosses.Add("Boss3", new Texture("Resources/Boss3.png"));
            Bosses.Add("Boss4", new Texture("Resources/Boss4.png"));
            Bosses.Add("Boss5", new Texture("Resources/Boss5.png"));

            Scale = new SFML.System.Vector2f(0.2f, 0.2f);
            Count++;
            switch (BossCount)
            {
                case 1:
                    {
                        this.Texture = new Texture(Bosses["Boss1"]);
                        break;
                    }
                case 2:
                    {
                        this.Texture = new Texture(Bosses["Boss2"]);
                        break;
                    }
                case 3:
                    {
                        this.Texture = new Texture(Bosses["Boss3"]);
                        break;
                    }
                case 4:
                    {
                        this.Texture = new Texture(Bosses["Boss4"]);
                        break;
                    }
                case 5:
                    {
                        this.Texture = new Texture(Bosses["Boss5"]);
                        break;
                    }
                default:
                    break;
            }
            Origin = new SFML.System.Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2);
            Collided += Boss_Collided;
        }

        private void Boss_Collided(Object ob)
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
           
            if (delta < 80)
                Position = new SFML.System.Vector2f(300, delta++);
            if (s.ElapsedMilliseconds > 1000)
            {
                s.Restart();
                World.AddObject(new Missile(Position, 90) { Speed = 3, Damage = 2, EnemySpawned = true });

            }
            if (Life <= 0)

            {
                Destroy();
                Score.score += 100;
            }
            if (Moving)
            {
                Position = new SFML.System.Vector2f(Position.X + speed, Position.Y);
            }
            else
            Position = new SFML.System.Vector2f(Position.X - speed, Position.Y);
            if (Position.X >= 600)
                Moving = false;
            else
                if (Position.X <= 100)
                Moving = true;
            
        }
        public override void Destroy()
        {
            if(rdn.Next(0, 3) == 1)
                World.AddObject(new TripleAttack() { PositionX = this.Position.X, PositionY = Position.Y });
            else
                World.AddObject(new DropLife() { PositionX = this.Position.X, PositionY = Position.Y });
            IsAlive = false;
            base.Destroy();
            Count--;
        }
    }
}

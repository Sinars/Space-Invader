using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Template
{
    class Player : Object
    {
        public  int PlayerLife { get; set; }
        private bool right, left, up, down;
        private float speed = 2;
        private int lastShoot, coolDown = 1000;
        public static int life;
        private int AttackType;
      
        public override void Init()
        {
            AttackType = 1;
            Texture = Resources.Texture[1];
            PlayerLife = 10;
            life = PlayerLife;
            Program.window.KeyPressed += Window_KeyPressed;
            Program.window.KeyReleased += Window_KeyReleased;
            Position = new SFML.System.Vector2f(Program.window.Size.X / 2, Program.window.Size.Y - 60);
            this.Scale = new SFML.System.Vector2f(0.5f, 0.5f);
            Origin = new SFML.System.Vector2f(Texture.Size.X / 2, Texture.Size.Y / 2);
            lastShoot = Environment.TickCount;
            Collided += Player_Collided;
        }

        private void Player_Collided(Object ob)
        {
            if (ob is Missile && ((Missile)ob).EnemySpawned)
            {
                PlayerLife--;
                life = PlayerLife;
                ob.Destroy();
            }
            if (ob is DropLife)
            {
                if (PlayerLife < 10)
                {
                    PlayerLife++;
                    life = PlayerLife;
                }
                ob.Destroy();
            }
            if (ob is TripleAttack)
            {
                AttackType = 2;
                ob.Destroy();
            }
            if (ob is AttackSpeed)
            {
                if (coolDown > 70)
                    coolDown -= 100;
                if (coolDown < 70)
                    coolDown = 70;
                ob.Destroy();
            }
        }


  
        private void Window_KeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.N)
            {
                Program.world.AddObject(new FinalBoss());
                GameSet.FinalWave = true;
            }
            switch (e.Code)
            {
                case Keyboard.Key.A:
                    left = false;
                    break;
                case Keyboard.Key.D:
                    right = false;
                    break;
                case Keyboard.Key.S:
                    down = false;
                    break;
                case Keyboard.Key.W:
                    up = false;
                    break;
                    
            }
        }

        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.A:
                    if (Position.X > 60)
                    {
                        left = true;
                       
                    }
                    break;
                case Keyboard.Key.D:
                    if (Position.X < Program.window.Size.X)
                        right = true;
                    break;
                case Keyboard.Key.S:
                    if (Position.Y < Program.window.Size.Y)
                        down = true;
                    break;
                case Keyboard.Key.W:
                    if (Position.Y > 60)
                        up = true;
                    break;
                default:
                    break;
            }
        }

        public override void Update()
        {
            if (up) Position -= new SFML.System.Vector2f(0, speed);
            if (down) Position += new SFML.System.Vector2f(0, speed);
            if (left) Position -= new SFML.System.Vector2f(speed, 0);
            if (right) Position += new SFML.System.Vector2f(speed, 0);
            switch (GameSet.GameMode)
            {
                case 1:
                    if (Environment.TickCount - lastShoot > coolDown)
                    {
                        lastShoot = Environment.TickCount;
                        var mouse = Mouse.GetPosition(Program.window);
                        // World.AddObject(new Missile(Position, -90) { Speed = 5, PlayerSpawned = true });
                        switch (AttackType)
                        {
                            case 1:
                                {
                                    World.AddObject(new Missile(Position, -90) { Speed = 5, PlayerSpawned = true });
                                    //World.AddObject(new Missile(Position, (float)Math.Atan2(-(Position.Y - mouse.Y), -(Position.X - mouse.X)) * 180 / (float)Math.PI)
                                    break;
                                }
                            case 2:
                                {
                                    World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X - 10, Position.Y)), -90)
                                    { Speed = 5, PlayerSpawned = true });
                                    World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X - 2, Position.Y)), -90)
                                    { Speed = 5, PlayerSpawned = true });
                                    World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X + 6, Position.Y)),-90)
                                    { Speed = 5, PlayerSpawned = true });

                                    break;
                                }

                            default:
                                break;
                        }
                    }
                    break;
                case 2:
                    {
                        coolDown = 70;
                        AttackType = 2;
                        if (Environment.TickCount - lastShoot > coolDown)
                        {
                            lastShoot = Environment.TickCount;
                            var mouse = Mouse.GetPosition(Program.window);
                            // World.AddObject(new Missile(Position, -90) { Speed = 5, PlayerSpawned = true });
                            switch (AttackType)
                            {
                                case 1:
                                    {
                                        World.AddObject(new Missile(Position, (float)Math.Atan2(-(Position.Y - mouse.Y), -(Position.X - mouse.X)) * 180 / (float)Math.PI) { Speed = 5, PlayerSpawned = true });
                                        break;
                                    }
                                case 2:
                                    {
                                        World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X - 10, Position.Y)), (float)Math.Atan2(-(Position.Y - mouse.Y), -(Position.X - mouse.X)) * 180 / (float)Math.PI)
                                        { Speed = 5, PlayerSpawned = true });
                                        World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X - 2, Position.Y)), (float)Math.Atan2(-(Position.Y - mouse.Y), -(Position.X - mouse.X)) * 180 / (float)Math.PI)
                                        { Speed = 5, PlayerSpawned = true });
                                        World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X + 6, Position.Y)), (float)Math.Atan2(-(Position.Y - mouse.Y), -(Position.X - mouse.X)) * 180 / (float)Math.PI)
                                        { Speed = 5, PlayerSpawned = true });

                                        break;
                                    }

                                default:
                                    break;
                            }
                        }
                    }
                    break;
            }

                //World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X - 10, Position.Y)), (float)Math.Atan2(-(Position.Y - mouse.Y), -(Position.X - mouse.X)) * 180 / (float)Math.PI)
                //       { Speed = 5, PlayerSpawned = true });
                //           World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X - 2, Position.Y)), (float)Math.Atan2(-(Position.Y - mouse.Y), -(Position.X - mouse.X)) * 180 / (float)Math.PI)
                //           { Speed = 5, PlayerSpawned = true });
                //          World.AddObject(new Rocket((new SFML.System.Vector2f(Position.X + 6, Position.Y)), (float)Math.Atan2(-(Position.Y - mouse.Y), -(Position.X - mouse.X)) * 180 / (float)Math.PI)
                //          { Speed = 5, PlayerSpawned = true });

            
            if (PlayerLife <= 0)
            {
                
                Destroy();                    
                GameSet.ActiveMenu = 3;
            }
           
            
            

        }

        public override void Destroy()
        {
            Program.window.KeyPressed -= Window_KeyPressed;//Erase events
            Program.window.KeyReleased -= Window_KeyReleased;
            base.Destroy();
            IsAlive = false;
        }

    }
}

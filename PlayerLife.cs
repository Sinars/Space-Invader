using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.System;
namespace Template
{
    class PlayerLife : Player
    {
        public override void Init()
        {
            this.Position = new Vector2f(700, 400);
            this.Scale = new Vector2f(0.2f, 0.2f);
        }
        public override void Update()
        {
            switch (Player.life)
            {
                case 1:
                    this.Texture = Resources.LifeBar["1"];
                    break;
                case 2:
                    this.Texture = Resources.LifeBar["2"];
                    break;
                case 3:
                    this.Texture = Resources.LifeBar["3"];
                    break;
                case 4:
                    this.Texture = Resources.LifeBar["4"];
                    break;
                case 5:
                    this.Texture = Resources.LifeBar["5"];
                    break;
                case 6:
                    this.Texture = Resources.LifeBar["6"];
                    break;
                case 7:
                    this.Texture = Resources.LifeBar["7"];
                    break;
                case 8:
                    this.Texture = Resources.LifeBar["8"];
                    break;
                case 9:
                    this.Texture = Resources.LifeBar["9"];
                    break;
                case 10:
                    {
                        this.Texture = Resources.LifeBar["Full"];
                        break;
                    }
                default:
                    {
                        this.Destroy();
                        break;
                    }
            }
        }
        public override void Destroy()
        {
            base.Destroy();
            IsAlive = false;
        }
    }
}

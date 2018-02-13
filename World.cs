using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Template
{
    class World
    {
        public List<Object> Objects = new List<Object>();
        
        public void AddObject(Object ob)
        {
            ob.Init();
            ob.World = this;
            Objects.Add(ob);
        }
        public void update()
        {
            
            
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].IsAlive)
                {
                    Objects[i].Update();
                    for (int j = i + 1; j < Objects.Count; j++)
                    {
                        if (Objects[i].CollidesWith(Objects[j]))
                        {
                            Objects[i].CollidedWith(Objects[j]);
                            Objects[j].CollidedWith(Objects[i]);
                        }
                    }

                }
                else
                {
                    Objects.RemoveAt(i--);
                }
            }
           // Console.WriteLine(Objects.Count);
        }
        public void Draw(RenderWindow window)
        {
                for (int i = 0; i < Objects.Count; i++)
                    window.Draw(Objects[i]);
        }
        public void EndGame()
        {
            for (int i = 1; i < Objects.Count(); i++)
                Objects[i].Destroy();
            
               
        }
        public bool AllDestroyed()
        {
            foreach(Object ob in Objects)
                if(ob is EnemyShip || ob is Boss || ob is FinalBoss)
            return false;
            return true;
        }


    }
}

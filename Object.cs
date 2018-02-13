using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
namespace Template
{
    delegate void Collision(Object ob);
    abstract class Object:Sprite
    {
        public bool IsAlive=true;
       // public bool IsActiveCollider = false;

        public World World;
        public event Collision Collided;
        public virtual bool CollidesWith(Object ob)
        {
           return GetGlobalBounds().Intersects(ob.GetGlobalBounds());
        }

        public void CollidedWith(Object ob)
        {
            if (Collided != null)
                Collided(ob);
        }
        public abstract void Init();
        public abstract void Update();
        public virtual void Destroy()
        {
            IsAlive = false;
        }
        
    }
}

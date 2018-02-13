using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    class Background : Object
    {
        private float y = -2000;

        public override void Init()
        {
            this.Texture = Resources.Texture[0];       
        }

        public override void Update()
        {
            this.Position = new SFML.System.Vector2f(0, y++);
            if (y == 0)
                y = -2000;  
        }
        
    }
}

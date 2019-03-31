using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UntitledPirateGame
{
    class SolidStationaryEntity: Entity, ICollidable
    {
        bool collidable;
        public bool HasCollision
        {
            get { return collidable; }
            set { collidable = value; }
        }
        public SolidStationaryEntity(int width, int height, int x, int y, int elevation, float rotation,bool isVisible, Texture2D sprite, bool collidable = true )
            :base(width, height, x, y, elevation, rotation, isVisible, sprite)
        {
            this.collidable = collidable;   
        }
    }
}

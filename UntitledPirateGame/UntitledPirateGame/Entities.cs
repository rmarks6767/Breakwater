using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledPirateGame
{
    class Entities
    {
        /* Entities Include but are not limited to:
         * -The Player
         * -Enemies
         * -Any buildings
         * -Ships
         */
        public struct entityVariables
        {
            //name and type of entity being created
            public string name;
            public string type;

            // Origin of the original object
            public int originX;
            public int originY;

            // "depth" of the object, position on the layers on the screen
            public int elevation;

            // if the object is visible on the screen
            public bool isVisible;

            //the graphics stuff for the entity
            public Texture2D sprite;
            public Rectangle collisionBox;
        }
        public Entities(int width, int height, int originX, int originY, int elevation, bool isVisible, Texture2D sprite)
        {
            //set the collision box based on the origin 
            entityVariables.collisionBox = new Rectangle((originX - (width / 2)), (originY - (height / 2)), width, height);
            entityVariables.elevation = elevation;
            entityVariables.isVisible = isVisible;
            entityVariables.sprite = sprite;


        }
    }
}

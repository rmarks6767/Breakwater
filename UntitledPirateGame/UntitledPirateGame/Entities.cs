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
         * -etc.
         */
        public struct EntityVariables
        {

            /// <summary>
            ///name of entity being created 
            /// </summary>
            public string name;

            /// <summary>
            ///type of entity being created 
            /// </summary>
            public string type;

            /// Origin of the original object
            public int originX;
            public int originY;

            // "depth" of the object, position on the layers on the screen
            public int elevation;

            // rotation of the object in radians
            public float rotation;

            // if the object is visible on the screen
            public bool isVisible;

            //the graphics stuff for the entity
            public Texture2D sprite;
            public Rectangle collisionBox;
        }
        
        /// <summary>
        /// Determine whether or not this entity is on screen or not
        /// </summary>
        public bool OnScreen
        {
            get
            {
                if (CoordinateMath.RectanglesOverLap(Vars.collisionBox,Screen.ScreenRectangle))
                {
                    return true;
                }
                return false;
            }
        }

        //creating the struct so it may be accessed outside of the class
        private EntityVariables vars;

        public EntityVariables Vars { get { return vars; } }

        public Entities(int width, int height, int originX, int originY, int elevation, float rotation, bool isVisible, Texture2D sprite)
        {
            //create the struct to hold the variables for the entity
            vars = new EntityVariables
            {
                //set the collision box based on the origin
                collisionBox = new Rectangle((originX - (width / 2)), (originY - (height / 2)), width, height),
                elevation = elevation,
                isVisible = isVisible,
                sprite = sprite,
                rotation = rotation
            };
        }
    }
}

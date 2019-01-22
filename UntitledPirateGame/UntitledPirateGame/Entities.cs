using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledPirateGame
{
    class Entity
    {
        /* Entity Include but are not limited to:
         * -The Player
         * -Enemies
         * -Any buildings
         * -Ships
         * -etc.
         */
        public struct EntityVariables
        {
            /// <summary>
            /// Sprite for the entity
            /// </summary>
            public Texture2D sprite;

            /// <summary>
            /// Collision and drawing rectangle
            /// </summary>
            public Rectangle Rectangle;

            /// <summary>
            /// Elevation of entity drawn on the screen
            /// </summary>
            public int elevation;

            /// <summary>
            /// Whether or not the entity will be have its sprite drawn onto the screen
            /// </summary>
            public bool isVisible;

            /// <summary>
            /// The rotation of the sprite drawn on screen
            /// </summary>
            public float rotation;
        }
        
        /// <summary>
        /// Determine whether or not this entity is on screen or not
        /// </summary>
        public bool OnScreen
        {
            get
            {
                if (CoordinateMath.RectanglesOverLap(Screen.ScreenRectangle,vars.Rectangle) || CoordinateMath.RectanglesOverLap(vars.Rectangle,Screen.ScreenRectangle))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Struct of the stored variables of the entity
        /// </summary>
        public EntityVariables vars;

        public Entity(int width, int height, int x, int y, int elevation, float rotation, bool isVisible, Texture2D sprite)
        {
            //create the struct to hold the variables for the entity
            vars = new EntityVariables
            {
                //set the collision box based on the origin
                Rectangle = new Rectangle(x,y, width, height),
                elevation = elevation,
                isVisible = isVisible,
                sprite = sprite,
                rotation = rotation
            };
        }
    }
}

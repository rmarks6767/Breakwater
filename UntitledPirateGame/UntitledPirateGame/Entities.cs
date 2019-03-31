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
            private int width;
            private int height;
            /// <summary>
            /// Circle used for collisions
            /// </summary>
            public Circle Circle
            {
                get { return new Circle(new Point((int)DrawingVector.X, (int)DrawingVector.Y), width); }
            }

            /// <summary>
            /// Vector used for drawing
            /// </summary>
            public Vector2 DrawingVector;

            /// <summary>
            /// Rectangle used for collisions
            /// </summary>
            public Rectangle CollisionRectangle
            {
                get { return new Rectangle((int)DrawingVector.X + (width / 2), (int)DrawingVector.Y + (height / 2), width, height); }
            }
                 

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

            /// <summary>
            /// The leaf in which this entity belongs to
            /// (WARNING! THIS WILL ALWAYS BE NULL UNLESS THIS OBJECT HAS ICOLLIDABLE)
            /// </summary>
            public QuadTree leaf;
        }
        
        /// <summary>
        /// Determine whether or not this entity is on screen or not
        /// </summary>
        public bool OnScreen
        {
            get
            {
                if (CoordinateMath.RectanglesOverLap(Screen.ScreenRectangle,vars.CollisionRectangle) || CoordinateMath.RectanglesOverLap(vars.CollisionRectangle,Screen.ScreenRectangle))
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

        public Entity(int width, int height, int originx, int originy, int elevation, float rotation, bool isVisible, Texture2D sprite)
        {
            //create the struct to hold the variables for the entity
            vars = new EntityVariables
            {
                DrawingVector = new Vector2(originx, originy),
                elevation = elevation,
                isVisible = isVisible,
                sprite = sprite,
                rotation = rotation
            };
        }
    }
}

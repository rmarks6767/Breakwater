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
    static class Screen
    {

        static int x1, y1 = 0;
        static Game1 game;

        /// <summary>
        /// The screen's world x1 coordinate
        /// </summary>
        public static int X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        /// <summary>
        /// The screen's world y1 coordinate
        /// </summary>
        public static int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        /// <summary>
        /// The screen's world x2 coordinate
        /// </summary>
        public static int X2
        {
            get { return x1 + game.GraphicsDevice.Viewport.Width; }
        }

        /// <summary>
        /// The sreen's world y2 coordinate
        /// </summary>
        public static int Y2
        {
            get { return y1 + game.GraphicsDevice.Viewport.Height; }
        }

        public static Rectangle ScreenRectangle
        {
            get {
                Rectangle rect = new Rectangle(x1, y1, X2 - x1, Y2 - y1);
                return rect;
            }
            
        }

        /// <summary>
        /// Assign the game object for access of the graphics engine
        /// </summary>
        /// <param name="g"></param>
        public static void SetGame(Game1 g)
        {
            game = g;
        }



    }
}
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

        static int x, y;
        static public GraphicsDevice GraphicsDevice;
        static Game1 game;
        
        public static int ScreenWidth
        {
            get
            {
                return GraphicsDevice.Viewport.Width;
            }
            
        }

        public static int ScreenHeight
        {
            get
            {
                return GraphicsDevice.Viewport.Height;
            }
        }

        /// <summary>
        /// Origin X value of screen
        /// </summary>
        public static int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Origin Y value of the screen
        /// </summary>
        public static int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// The screen's world x1 coordinate
        /// </summary>
        public static int X1
        {
            get { return X - (ScreenWidth/2); }
        }

        /// <summary>
        /// The screen's world y1 coordinate
        /// </summary>
        public static int Y1
        {
            get { return Y - (ScreenHeight/2); }
        }

        /// <summary>
        /// The screen's world x2 coordinate
        /// </summary>
        public static int X2
        {
            get { return X1 + ScreenWidth; }
        }

        /// <summary>
        /// The sreen's world y2 coordinate
        /// </summary>
        public static int Y2
        {
            get { return Y1 + ScreenHeight; }
        }

        public static Rectangle ScreenRectangle
        {
            get {
                return new Rectangle(X1, Y1, ScreenWidth, ScreenHeight);
            }
            
        }

        /// <summary>
        /// Assign the game object for access of the graphics engine
        /// </summary>
        /// <param name="g"></param>
        public static void SetGame(Game1 g)
        {
            game = g;
            GraphicsDevice = game.GraphicsDevice;
        }

    }
}
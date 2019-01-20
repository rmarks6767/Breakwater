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

        static double x1, y1 = 0;
        static Game1 game;

        /// <summary>
        /// The screen's world x1 coordinate
        /// </summary>
        static double X1
        {
            get { return x1; }
            set { x1 = value; }
        } 

        /// <summary>
        /// The screen's world y1 coordinate
        /// </summary>
        static double Y1
        {
            get { return y1;  }
            set { y1 = value; }
        }

        /// <summary>
        /// The screen's world x2 coordinate
        /// </summary>
        static double X2
        {
            get { return x1 + game.GraphicsDevice.Viewport.Width ; }
        }

        /// <summary>
        /// The sreen's world y2 coordinate
        /// </summary>
        static double Y2
        {
            get { return y1 + game.GraphicsDevice.Viewport.Height; }
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

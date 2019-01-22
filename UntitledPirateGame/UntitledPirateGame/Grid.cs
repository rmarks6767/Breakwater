using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    class Grid
    {
        public char[,] grid;

        /// <summary>
        /// Initializes the grid with just blank points 
        /// </summary>
        /// <param name="width">The width of the entire world</param>
        /// <param name="height">The height of the entire world</param>
        public Grid(int width, int height)
        {
            grid = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int g = 0; g < width; g++)
                {
                    if (i == 0 || g == 0 || i == height || g == width)
                    {
                        grid[i, g] = 'X';
                    }
                    else
                    {
                        grid[i, g] = ' ';
                    }
                }
            }
        }

        /// <summary>
        /// Only for the things that cannot be moved ever, this is the nondynamic portion
        /// </summary>
        /// <param name="rect"></param>
        public void AddInaccessable(Rectangle rect)
        {
            for (int i = rect.Y; i < rect.Height; i++)
            {
                for (int g = rect.X; g < rect.Width; g++)
                {
                    grid[i, g] = 'X';
                }
            }
        }
    }
}

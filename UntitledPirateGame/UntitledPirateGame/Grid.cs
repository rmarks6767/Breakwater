using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    /// <summary>
    /// Universal 'Starting grid' that every npc will clone 
    /// </summary>
    class Grid
    {
        /// <summary>
        /// Stores all static members positions in a char array, based on map size
        /// </summary>
        public char[,] grid;

        /// <summary>
        /// The size of the map's width 
        /// </summary>
        private int mapWidth;

        /// <summary>
        /// The size of the map's height 
        /// </summary>
        private int mapHeight;

        //All the properties to return the stuff
        public char[,] GetGrid { get { return grid; } }
        public int MapWidth { get { return mapWidth; } }
        public int MapHeight { get { return mapHeight; } }

        /// <summary>
        /// Used for building the initial grid, the one that will be copied by all objects
        /// </summary>
        /// <param name="mapWidth">Width of the entire map</param>
        /// <param name="mapHeight">Height of the entire map</param>
        public Grid(int mapWidth, int mapHeight)
        {
            grid = new char[mapHeight, mapWidth];
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            for (int i = 0; i < MapWidth; i++)
            {
                for (int ii = 0; ii < MapHeight; ii++)
                {
                    grid[i, ii] = ' ';
                }
            }

            grid[0, 4] = 'X';
            grid[1, 4] = 'X';
            grid[2, 4] = 'X';
            grid[3, 4] = 'X';
            grid[4, 4] = 'X';
            grid[5, 4] = 'X';
            grid[6, 4] = 'X';
            grid[7, 4] = 'X';
            grid[8, 4] = 'X';
            grid[9, 4] = 'X';
            grid[10, 4] = 'X';
            grid[11, 4] = 'X';
            grid[12, 4] = 'X';
            grid[13, 4] = 'X';
            grid[14, 4] = 'X';
            grid[15, 4] = 'X';
            grid[16, 4] = 'X';
            grid[17, 4] = 'X';
            grid[18, 4] = 'X';
            grid[19, 4] = 'X';



        }

        /// <summary>
        /// Constuctor used to create a grid for an entity, based off of the initial grid that was made
        /// </summary>
        /// <param name="grid">Grid that was already created</param>
        public Grid(char[,] grid)
        {
            this.grid = (char[,])grid.Clone();
            mapWidth = grid.GetLength(0);
            mapHeight = grid.GetLength(1);
        }

        /// <summary>
        /// Adds the collision boxes to the grid of objects that never move
        /// </summary>
        /// <param name="rect"></param>
        public void AddStaticEntity(Rectangle rect)
        {
            for (int i = rect.X; i < rect.Height; i++)
            {
                for (int ii = 0; ii < rect.Width; ii++)
                {
                    grid[i, ii] = 'X';
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame.PathFinding
{
    /// <summary>
    /// Universal 'Starting grid' that every npc will clone 
    /// </summary>
    class Grid
    {
        /// <summary>
        /// Stores all static members positions in a char array, based on map size
        /// </summary>
        public Node[,] grid;

        /// <summary>
        /// The size of the map's width 
        /// </summary>
        private int mapWidth;

        /// <summary>
        /// The size of the map's height 
        /// </summary>
        private int mapHeight;

        //All the properties to return the stuff
        public Node[,] GetGrid { get { return grid; } }
        public int MapWidth { get { return mapWidth; } }
        public int MapHeight { get { return mapHeight; } }

        /// <summary>
        /// Used for building the initial grid, the one that will be copied by all objects
        /// </summary>
        /// <param name="mapWidth">Width of the entire map</param>
        /// <param name="mapHeight">Height of the entire map</param>
        public Grid(int mapWidth, int mapHeight)
        {
            grid = new Node[mapWidth, mapHeight];
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            for (int i = 0; i < MapHeight; i++)
            {
                for (int ii = 0; ii < MapWidth; ii++)
                {
                    grid[ii, i] = new Node(ii, i);
                }
            }
        }

        /// <summary>
        /// Constuctor used to create a grid for an entity, based off of the initial grid that was made
        /// </summary>
        /// <param name="grid">Grid that was already created</param>
        public Grid(Node[,] grid)
        {
            this.grid = (Node[,])grid.Clone();
            mapWidth = grid.GetLength(0);
            mapHeight = grid.GetLength(1);
        }

        /// <summary>
        /// Adds the collision boxes to the grid of objects that never move
        /// </summary>
        /// <param name="rect"></param>
        public void AddStaticEntity(Rectangle rect)
        {
            for (int i = rect.X; i < rect.Width + rect.X; i++)
            {
                for (int ii = rect.Y; ii < rect.Height + rect.Y; ii++)
                {
                    grid[ii, i].Walkable = false;
                }
            }
        }

    }
}

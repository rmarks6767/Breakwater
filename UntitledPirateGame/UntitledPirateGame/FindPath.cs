using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    class FindPath
    {
        private Vector2 startPoint;
        private Vector2 endPoint;
        private Grid grid;

        public Grid Grid { get { return grid; } }

        /// <summary>
        /// This class will ultimately return the path at which an npc has to take to get to a given spot
        /// </summary>
        /// <param name="startPoint">Where the npc is at the start time</param>
        /// <param name="endPoint">Where the npc wants to go</param>
        /// <param name="grid">The main grid that contains all of the points that exist on the screen / world.  Contains the points that nodes that need to be checked</param>
        public FindPath(Vector2 startPoint, Vector2 endPoint, Grid grid)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.grid = grid;
        }

        /// <summary>
        /// The actual algorithm for the algorithm
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="checkedNodes"></param>
        /// <param name="nodesToCheck"></param>
        private void AStar(Grid grid, Vector2 startPoint, Vector2 endPoint)
        {
            List<AstarNode> openNodes = new List<AstarNode>();
            List<AstarNode> closedNodes = new List<AstarNode>();

            AstarNode startNode = new AstarNode(startPoint, startPoint, endPoint);

            AstarNode endNode = new AstarNode(endPoint, startPoint, endPoint);

            openNodes.Add(startNode);

            /*for (int i = 0; i < grid.Height; i++)
            {
                for (int g = 0; g < grid.Width; g++)
                {
                    if (grid.grid[i, g] == ' ' || (startPoint.X == i && startPoint.Y == g))
                    {
                        openNodes.Add(new AstarNode(new Vector2(i, g), startPoint, endPoint));
                    }
                }
            }*/

            while (openNodes.Count > 0)
            {
                AstarNode currentNode = openNodes[0];

                if (openNodes[0].NodePos.X == endPoint.X
                    && openNodes[0].NodePos.Y == endPoint.Y)
                {
                    return;
                }

                //add the nodes that are around it to the open nodes
                int X = (int)openNodes[0].NodePos.X;
                int Y = (int)openNodes[0].NodePos.Y;

                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X + 1, Y] != 'X')
                {
                    openNodes.Add(new AstarNode(new Vector2(X + 1, Y), startPoint, endPoint));
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X - 1, Y] != 'X')
                {
                    openNodes.Add(new AstarNode(new Vector2(X - 1, Y), startPoint, endPoint));
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X, Y + 1] != 'X')
                {
                    openNodes.Add(new AstarNode(new Vector2(X, Y + 1), startPoint, endPoint));
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X, Y - 1] != 'X')
                {
                    openNodes.Add(new AstarNode(new Vector2(X, Y - 1), startPoint, endPoint));
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X + 1, Y + 1] != 'X')
                {
                    openNodes.Add(new AstarNode(new Vector2(X + 1, Y + 1), startPoint, endPoint));
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X + 1, Y - 1] != 'X')
                {
                    openNodes.Add(new AstarNode(new Vector2(X + 1, Y - 1), startPoint, endPoint));
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X - 1, Y + 1] != 'X')
                {
                    openNodes.Add(new AstarNode(new Vector2(X - 1, Y + 1), startPoint, endPoint));
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X - 1, Y + 1] != 'X')
                {
                    openNodes.Add(new AstarNode(new Vector2(X - 1, Y - 1), startPoint, endPoint));
                }

                //starts at 1 because that is the parent node
                for (int i = 1; i < openNodes.Count - 1; i++)
                {
                    int successorCurrentCost = openNodes[i].F;


                }
            }
        }
    }
    class AstarNode
    {
        private int g;
        private int h;
        private int f;
        private Vector2 nodePos;

        public Vector2 NodePos { get { return nodePos; } }
        public int G { get { return g; } } //set { g = value; } }
        public int H { get { return h; } }//set { h = value; } }
        public int F { get { return f; } }//set { f = value; } }

        public AstarNode(Vector2 nodePos, Vector2 startPos, Vector2 endPos)
        {
            this.nodePos = nodePos;
            this.h = (int)Math.Sqrt(Math.Pow((nodePos.X - endPos.X),2) + Math.Pow((nodePos.Y - endPos.Y), 2));
            this.g = (int)Math.Sqrt(Math.Pow((nodePos.X - startPos.X), 2) + Math.Pow((nodePos.Y - startPos.Y), 2)); ;
            this.f = h + g;
        }

    }
}

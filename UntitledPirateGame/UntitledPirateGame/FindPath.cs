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

            AstarNode currentNode = openNodes[0];

            while (openNodes.Count > 0)
            {
                if (openNodes[0].NodePos.X == endPoint.X
                    && openNodes[0].NodePos.Y == endPoint.Y)
                {
                    return;
                }

                //add the nodes that are around it to the open nodes
                int X = (int)currentNode.NodePos.X;
                int Y = (int)currentNode.NodePos.Y;

                AstarNode parent = currentNode;
                AstarNode node1 = new AstarNode(new Vector2(X + 1, Y), startPoint, endPoint);
                AstarNode node2 = new AstarNode(new Vector2(X - 1, Y), startPoint, endPoint);
                AstarNode node3 = new AstarNode(new Vector2(X, Y + 1), startPoint, endPoint);
                AstarNode node4 = new AstarNode(new Vector2(X, Y - 1), startPoint, endPoint);
                AstarNode node5 = new AstarNode(new Vector2(X + 1, Y + 1), startPoint, endPoint);
                AstarNode node6 = new AstarNode(new Vector2(X + 1, Y - 1), startPoint, endPoint);
                AstarNode node7 = new AstarNode(new Vector2(X - 1, Y + 1), startPoint, endPoint);
                AstarNode node8 = new AstarNode(new Vector2(X - 1, Y - 1), startPoint, endPoint);

                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X + 1, Y] != 'X' && openNodes.Contains(node1))
                {
                    openNodes.Add(node1);
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X - 1, Y] != 'X' && openNodes.Contains(node2))
                {
                    openNodes.Add(node2);
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X, Y + 1] != 'X' && openNodes.Contains(node3))
                {
                    openNodes.Add(node3);
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X, Y - 1] != 'X' && openNodes.Contains(node4))
                {
                    openNodes.Add(node4);
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X + 1, Y + 1] != 'X' && openNodes.Contains(node5))
                {
                    openNodes.Add(node5);
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X + 1, Y - 1] != 'X' && openNodes.Contains(node6))
                {
                    openNodes.Add(node6);
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X - 1, Y + 1] != 'X' && openNodes.Contains(node7))
                {
                    openNodes.Add(node7);
                }
                if (X >= 0 && X < grid.Width && Y >= 0 && Y < grid.Height && grid.grid[X - 1, Y + 1] != 'X' && openNodes.Contains(node8))
                {
                    openNodes.Add(node8);
                }

                openNodes.Remove(parent);
                closedNodes.Add(parent);

                int lowestCost = openNodes[0].F;

                for (int i = 0; i < openNodes.Count; i++)
                {
                    if (openNodes[i].NodePos.X == endNode.NodePos.X && openNodes[i].NodePos.Y == endNode.NodePos.Y)
                    {
                        closedNodes.Add(openNodes[i]);
                        return;
                    }
                    if (openNodes[i].F < lowestCost)
                    {
                        lowestCost = openNodes[i].F;
                        currentNode = openNodes[i];
                    }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    class Node
    {
        //Values will not change after being set
        private int x;
        private int y;

        public List<Node> parents;
        private double g;
        private double h;
        private double f;
        private bool diag;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public double G { get { return g; } set { g = value; } }
        public double H { get { return h; } set { h = value; } }
        public double F { get { return g + h; } }
        public bool Diag { get { return diag; } }

        public Node(int x, int y, bool diag)
        {
            this.x = x;
            this.y = y;
            g = 0;
            h = 0;
            f = 0;
            this.diag = diag;
            parents = new List<Node>();
        }

        /// <summary>
        /// Used to get the h or g value
        /// </summary>
        /// <param name="currentPos">The node's starting x and y position</param>
        /// <param name="goingTo">The start or end node, denoted goingTo</param>
        /// <returns>returns the distance to either given point</returns>
        public double CalcDist(Vector2 currentPos, Vector2 goingTo)
        {
            return Math.Pow(currentPos.X - goingTo.X, 2) + Math.Pow(currentPos.X - goingTo.Y, 2);
        }
    }
}

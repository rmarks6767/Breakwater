using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    class Circle
    {
        Point origin;
        int radius;
        /// <summary>
        /// The origin of the circle
        /// </summary>
        public Point Origin
        {
            get { return origin; }
            set { origin = value; }
        } 

        /// <summary>
        /// X value of the origin
        /// </summary>
        public int X
        {
            get { return origin.X; }
            set { origin.X = value; }
        }

        /// <summary>
        /// Y Value of the origin
        /// </summary>
        public int Y
        {
            get { return origin.Y; }
            set { origin.Y = value; }
        }

        /// <summary>
        /// The radius of the circle
        /// </summary>
        public int Radius
        {
            get { return radius; }
            set { if (value > 0) { radius = value; } }
        }
        public Circle(Point origin,int radius)
        {
            this.origin = origin;
            this.radius = radius;
        }


        public Circle(int x1,int x2,int radius)
        {
            this.origin = new Point(x1, x2);
            this.radius = radius;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    static class CoordinateMath
    {
        /// <summary>
        /// Checks if a certain given set of points, if made into a rectange, contain a point
        /// </summary>
        /// <param name="boundx1">Rectangle x1</param>
        /// <param name="boundy1">Rectangle y1</param>
        /// <param name="boundx2">Rectangle x2</param>
        /// <param name="boundy2">Rectangle y2</param>
        /// <param name="pointx">Point x1</param>
        /// <param name="pointy">Point y1</param>
        /// <returns>Whether or not the point is contained inside of the bounds</returns>
        public static bool BoundsContain(int boundx1, int boundy1, int boundx2, int boundy2, int pointx, int pointy)
        {
            if (pointx > boundx1 && pointx < boundx2 && pointy > boundy1 && pointy < boundy2)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if a rectangle contains a given point
        /// </summary>
        /// <param name="Bounds"></param>
        /// <param name="pointx"></param>
        /// <param name="pointy"></param>
        /// <returns>Whether or not the point is contained inside of the bounds</returns>
        public static bool BoundsContain(Rectangle Bounds, int pointx, int pointy)
        {
            int boundx1 = Bounds.X;
            int boundy1 = Bounds.Y;
            int boundx2 = boundx1 + Bounds.Width;
            int boundy2 = boundy1 + Bounds.Height;
            if (pointx > boundx1 && pointx < boundx2 && pointy > boundy1 && pointy < boundy2)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a rectangle contains a given point
        /// </summary>
        /// <param name="Bounds"></param>
        /// <param name="pt"></param>
        /// <returns>Whether or not the point is contained inside of the bounds</returns>
        public static bool BoundsContain(Rectangle Bounds, Point pt)
        {
            int boundx1 = Bounds.X;
            int boundy1 = Bounds.Y;
            int boundx2 = boundx1 + Bounds.Width;
            int boundy2 = boundy1 + Bounds.Height;
            int pointx = pt.X;
            int pointy = pt.Y;
            if (pointx > boundx1 && pointx < boundx2 && pointy > boundy1 && pointy < boundy2)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if given rect1 contains any points of rect2 in anyway
        /// </summary>
        /// <param name="rect1"></param>
        /// <param name="rect2"></param>
        /// <returns></returns>
        public static bool RectanglesOverLap(Rectangle rect1, Rectangle rect2)
        {
            int x1 = rect2.X;
            int y1 = rect2.Y;
            int x2 = x1 + rect2.Width;
            int y2 = y1 + rect2.Height;
            if (BoundsContain(rect1,x1,y1) || BoundsContain(rect1,x1,y2) || BoundsContain(rect1,x2,y1) || BoundsContain(rect1,x2,y2))
            {
                return true;
            }
            return false;
        }
    }
}

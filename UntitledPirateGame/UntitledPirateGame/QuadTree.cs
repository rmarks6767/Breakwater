﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledPirateGame
{
    class QuadTree
    {
        /// All four boxes 
        private List<Entity> nw;
        private List<Entity> ne;
        private List<Entity> sw;
        private List<Entity> se;

        /// <summary>
        /// All the new QuadTrees
        /// </summary>
        private QuadTree _nw = null;
        private QuadTree _ne = null;
        private QuadTree _sw = null;
        private QuadTree _se = null;

        //properties for the boxes
        public List<Entity> NW { get { return nw; } }
        public List<Entity> NE { get { return ne; } }
        public List<Entity> SW { get { return sw; } }
        public List<Entity> SE { get { return se; } }

        public QuadTree(List<Entity> boxes, double x1, double x2, double y1, double y2)
        {
            double halfLength = x2 - x1 / 2;
            double halfHeight = y2 - y1 / 2;

            if (boxes.Count > 1)
            {
                
                for (int i = 0; i < boxes.Count; i++)
                {
                    
                    //nw
                    if ((x1 <= boxes[i].vars.CollisionRectangle.X && boxes[i].vars.CollisionRectangle.X <= (x1 + halfLength))                 //top left 
                        && (y1 <= boxes[i].vars.CollisionRectangle.Y && boxes[i].vars.CollisionRectangle.Y <= (y1 + halfHeight))
                        || (x1 <= boxes[i].vars.CollisionRectangle.Width && boxes[i].vars.CollisionRectangle.Width <= (x1 + halfLength))      //top right
                        && (y1 <= boxes[i].vars.CollisionRectangle.Y && boxes[i].vars.CollisionRectangle.Y <= (y1 + halfHeight))
                        || (x1 <= boxes[i].vars.CollisionRectangle.X && boxes[i].vars.CollisionRectangle.X <= (x1 + halfLength))              //bottom left
                        && (y1 <= boxes[i].vars.CollisionRectangle.Height && boxes[i].vars.CollisionRectangle.Height <= (y1 + halfHeight))
                        || (x1 <= boxes[i].vars.CollisionRectangle.Width && boxes[i].vars.CollisionRectangle.Width <= (x1 + halfLength))      //bottom right
                        && (y1 <= boxes[i].vars.CollisionRectangle.Height && boxes[i].vars.CollisionRectangle.Height <= (y1 + halfHeight)))
                    {
                        nw.Add(boxes[i]);
                    }
                    //ne
                    if (((x1 + halfLength) <= boxes[i].vars.CollisionRectangle.X && boxes[i].vars.CollisionRectangle.X <= x2)                 //top left 
                        && (y1 <= boxes[i].vars.CollisionRectangle.Y && boxes[i].vars.CollisionRectangle.Y <= (y1 + halfHeight))
                        || ((x1 + halfLength) <= boxes[i].vars.CollisionRectangle.Width && boxes[i].vars.CollisionRectangle.Width <= x2)      //top right
                        && (y1 <= boxes[i].vars.CollisionRectangle.Y && boxes[i].vars.CollisionRectangle.Y <= (y1 + halfHeight))
                        || ((x1 + halfLength) <= boxes[i].vars.CollisionRectangle.X && boxes[i].vars.CollisionRectangle.X <= x2)              //bottom left
                        && (y1 <= boxes[i].vars.CollisionRectangle.Height && boxes[i].vars.CollisionRectangle.Height <= (y1 + halfHeight))
                        || ((x1 + halfLength) <= boxes[i].vars.CollisionRectangle.Width && boxes[i].vars.CollisionRectangle.Width <= x2)      //bottom right
                        && (y1 <= boxes[i].vars.CollisionRectangle.Height && boxes[i].vars.CollisionRectangle.Height <= (y1 + halfHeight)))
                    {
                        ne.Add(boxes[i]);
                    }
                    //sw
                    if ((x1 <= boxes[i].vars.CollisionRectangle.X && boxes[i].vars.CollisionRectangle.X <= (x1 + halfLength))                 //top left 
                        && ((y1 + halfHeight) <= boxes[i].vars.CollisionRectangle.Y && boxes[i].vars.CollisionRectangle.Y <= y2)
                        || (x1 <= boxes[i].vars.CollisionRectangle.Width && boxes[i].vars.CollisionRectangle.Width <= (x1 + halfLength))      //top right
                        && ((y1 + halfHeight) <= boxes[i].vars.CollisionRectangle.Y && boxes[i].vars.CollisionRectangle.Y <= y2)
                        || (x1 <= boxes[i].vars.CollisionRectangle.X && boxes[i].vars.CollisionRectangle.X <= (x1 + halfLength))              //bottom left
                        && ((y1 + halfHeight) <= boxes[i].vars.CollisionRectangle.Height && boxes[i].vars.CollisionRectangle.Height <= y2)
                        || (x1 <= boxes[i].vars.CollisionRectangle.Width && boxes[i].vars.CollisionRectangle.Width <= (x1 + halfLength))      //bottom right
                        && ((y1 + halfHeight) <= boxes[i].vars.CollisionRectangle.Height && boxes[i].vars.CollisionRectangle.Height <= y2))
                    {
                        sw.Add(boxes[i]);
                    }
                    //se
                    if (((x1 + halfLength) <= boxes[i].vars.CollisionRectangle.X && boxes[i].vars.CollisionRectangle.X <= x2)                 //top left 
                        && ((y1 + halfHeight) <= boxes[i].vars.CollisionRectangle.Y && boxes[i].vars.CollisionRectangle.Y <= y2)
                        || ((x1 + halfLength) <= boxes[i].vars.CollisionRectangle.Width && boxes[i].vars.CollisionRectangle.Width <= x2)      //top right
                        && ((y1 + halfHeight) <= boxes[i].vars.CollisionRectangle.Y && boxes[i].vars.CollisionRectangle.Y <= y2)
                        || ((x1 + halfLength) <= boxes[i].vars.CollisionRectangle.X && boxes[i].vars.CollisionRectangle.X <= x2)              //bottom left
                        && ((y1 + halfHeight) <= boxes[i].vars.CollisionRectangle.Height && boxes[i].vars.CollisionRectangle.Height <= y2)
                        || ((x1 + halfLength) <= boxes[i].vars.CollisionRectangle.Width && boxes[i].vars.CollisionRectangle.Width <= x2)      //bottom right
                        && ((y1 + halfHeight) <= boxes[i].vars.CollisionRectangle.Height && boxes[i].vars.CollisionRectangle.Height <= y2))
                    {
                        se.Add(boxes[i]);
                    }
                }
                
                //create the new QuadTrees (leaves)
                _nw = new QuadTree(nw, x1, y1, x1 + halfLength, y1 + halfHeight);
                _ne = new QuadTree(ne, x1 + halfLength, y1, x2, y1 + halfHeight);
                _sw = new QuadTree(sw, x1, y1 + halfHeight, x1 + halfLength, y2);
                _se = new QuadTree(se, x1 + halfLength, y1 + halfHeight, x2, y2);
            }
        }
    }
}

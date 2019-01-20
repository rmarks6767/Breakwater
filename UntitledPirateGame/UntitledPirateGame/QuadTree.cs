using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledPirateGame
{
    class QuadTree
    {
        /// All four boxes 
        private List<Entities> nw;
        private List<Entities> ne;
        private List<Entities> sw;
        private List<Entities> se;

        /// <summary>
        /// All the new QuadTrees
        /// </summary>
        private QuadTree _nw = null;
        private QuadTree _ne = null;
        private QuadTree _sw = null;
        private QuadTree _se = null;

        //properties for the boxes
        public List<Entities> NW { get { return nw; } }
        public List<Entities> NE { get { return ne; } }
        public List<Entities> SW { get { return sw; } }
        public List<Entities> SE { get { return se; } }

        public QuadTree(List<Entities> boxes, double x1, double x2, double y1, double y2)
        {
            if (boxes.Count > 1)
            {
                for (int i = 0; i < boxes.Count; i++)
                {
                    //nw

                    if ((x1 <= boxes[i].Vars.collisionBox.X && boxes[i].Vars.collisionBox.X <= (x2 / 2))                 //top left 
                        && (y1 <= boxes[i].Vars.collisionBox.Y && boxes[i].Vars.collisionBox.Y <= (y2 / 2))
                        || (x1 <= boxes[i].Vars.collisionBox.Width && boxes[i].Vars.collisionBox.Width <= (x2 / 2))      //top right
                        && (y1 <= boxes[i].Vars.collisionBox.Y && boxes[i].Vars.collisionBox.Y <= (y2 / 2))
                        || (x1 <= boxes[i].Vars.collisionBox.X && boxes[i].Vars.collisionBox.X <= (x2 / 2))              //bottom left
                        && (y1 <= boxes[i].Vars.collisionBox.Height && boxes[i].Vars.collisionBox.Height <= (y2 / 2))
                        || (x1 <= boxes[i].Vars.collisionBox.Width && boxes[i].Vars.collisionBox.Width <= (x2 / 2))      //bottom right
                        && (y1 <= boxes[i].Vars.collisionBox.Height && boxes[i].Vars.collisionBox.Height <= (y2 / 2)))
                    {
                        nw.Add(boxes[i]);
                    }
                    //ne
                    if (((x2 / 2) <= boxes[i].Vars.collisionBox.X && boxes[i].Vars.collisionBox.X <= x2)                 //top left 
                        && (y1 <= boxes[i].Vars.collisionBox.Y && boxes[i].Vars.collisionBox.Y <= (y2 / 2))
                        || ((x2 / 2) <= boxes[i].Vars.collisionBox.Width && boxes[i].Vars.collisionBox.Width <= x2)      //top right
                        && (y1 <= boxes[i].Vars.collisionBox.Y && boxes[i].Vars.collisionBox.Y <= (y2 / 2))
                        || ((x2 / 2) <= boxes[i].Vars.collisionBox.X && boxes[i].Vars.collisionBox.X <= x2)              //bottom left
                        && (y1 <= boxes[i].Vars.collisionBox.Height && boxes[i].Vars.collisionBox.Height <= (y2 / 2))
                        || ((x2 / 2) <= boxes[i].Vars.collisionBox.Width && boxes[i].Vars.collisionBox.Width <= x2)      //bottom right
                        && (y1 <= boxes[i].Vars.collisionBox.Height && boxes[i].Vars.collisionBox.Height <= (y2 / 2)))
                    {
                        ne.Add(boxes[i]);
                    }
                    //sw
                    if ((x1 <= boxes[i].Vars.collisionBox.X && boxes[i].Vars.collisionBox.X <= (x2 / 2))                 //top left 
                        && ((y2 / 2) <= boxes[i].Vars.collisionBox.Y && boxes[i].Vars.collisionBox.Y <= y2)
                        || (x1 <= boxes[i].Vars.collisionBox.Width && boxes[i].Vars.collisionBox.Width <= (x2 / 2))      //top right
                        && ((y2 / 2) <= boxes[i].Vars.collisionBox.Y && boxes[i].Vars.collisionBox.Y <= y2)
                        || (x1 <= boxes[i].Vars.collisionBox.X && boxes[i].Vars.collisionBox.X <= (x2 / 2))              //bottom left
                        && ((y2 / 2) <= boxes[i].Vars.collisionBox.Height && boxes[i].Vars.collisionBox.Height <= y2)
                        || (x1 <= boxes[i].Vars.collisionBox.Width && boxes[i].Vars.collisionBox.Width <= (x2 / 2))      //bottom right
                        && ((y2 / 2) <= boxes[i].Vars.collisionBox.Height && boxes[i].Vars.collisionBox.Height <= y2))
                    {
                        sw.Add(boxes[i]);
                    }
                    //se
                    if (((x2 / 2) <= boxes[i].Vars.collisionBox.X && boxes[i].Vars.collisionBox.X <= x2)                 //top left 
                        && ((y2 / 2) <= boxes[i].Vars.collisionBox.Y && boxes[i].Vars.collisionBox.Y <= y2)
                        || ((x2 / 2) <= boxes[i].Vars.collisionBox.Width && boxes[i].Vars.collisionBox.Width <= x2)      //top right
                        && ((y2 / 2) <= boxes[i].Vars.collisionBox.Y && boxes[i].Vars.collisionBox.Y <= y2)
                        || ((x2 / 2) <= boxes[i].Vars.collisionBox.X && boxes[i].Vars.collisionBox.X <= x2)              //bottom left
                        && ((y2 / 2) <= boxes[i].Vars.collisionBox.Height && boxes[i].Vars.collisionBox.Height <= y2)
                        || ((x2 / 2) <= boxes[i].Vars.collisionBox.Width && boxes[i].Vars.collisionBox.Width <= x2)      //bottom right
                        && ((y2 / 2) <= boxes[i].Vars.collisionBox.Height && boxes[i].Vars.collisionBox.Height <= y2))
                    {
                        se.Add(boxes[i]);
                    }
                }

                //create the new QuadTrees (leaves)
                _nw = new QuadTree(nw, x1, x2 / 2, y1, y2 / 2);
                _ne = new QuadTree(ne, x2 / 2, x2, y1, y2 / 2);
                _sw = new QuadTree(sw, x1, x2 / 2, y2 / 2, y2);
                _se = new QuadTree(se, x2 / 2, x2, y2 / 2, y2);
            }
        }
    }
}

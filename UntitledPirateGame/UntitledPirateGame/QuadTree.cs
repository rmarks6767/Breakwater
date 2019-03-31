using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    class QuadTree
    {
        /// All four boxes 
        const int LEAFTHRESHHOLD = 8;
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

        /// <summary>
        ///  x,y coords of the bounding rectangle
        /// </summary>
        double x1, x2, y1, y2;
        
        ///properties for the boxes
        public List<Entity> NW { get { return nw; } }
        public List<Entity> NE { get { return ne; } }
        public List<Entity> SW { get { return sw; } }
        public List<Entity> SE { get { return se; } }

        /// <summary>
        /// Members of the quadtree node
        /// </summary>
        public List<Entity> members;

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)x1,(int)y1,(int)(x2-x1),(int)(y2-y1)); }
        }

        public QuadTree(List<Entity> boxes, double x1, double x2, double y1, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;

            double halfLength = x2 - x1 / 2;
            double halfHeight = y2 - y1 / 2;
            members = new List<Entity>(boxes);
            if (boxes.Count > LEAFTHRESHHOLD)
            {
                
                //This might need a minus one to happen since we're removing members
                for (int i = 0; i < members.Count; i++)
                {
                    if (members[i] is ICollidable)
                    {
                        //nw
                        if ((x1 <= members[i].vars.CollisionRectangle.X && members[i].vars.CollisionRectangle.X <= (x1 + halfLength))                 //top left 
                            && (y1 <= members[i].vars.CollisionRectangle.Y && members[i].vars.CollisionRectangle.Y <= (y1 + halfHeight))
                            || (x1 <= members[i].vars.CollisionRectangle.Width && members[i].vars.CollisionRectangle.Width <= (x1 + halfLength))      //top right
                            && (y1 <= members[i].vars.CollisionRectangle.Y && members[i].vars.CollisionRectangle.Y <= (y1 + halfHeight))
                            || (x1 <= members[i].vars.CollisionRectangle.X && members[i].vars.CollisionRectangle.X <= (x1 + halfLength))              //bottom left
                            && (y1 <= members[i].vars.CollisionRectangle.Height && members[i].vars.CollisionRectangle.Height <= (y1 + halfHeight))
                            || (x1 <= members[i].vars.CollisionRectangle.Width && members[i].vars.CollisionRectangle.Width <= (x1 + halfLength))      //bottom right
                            && (y1 <= members[i].vars.CollisionRectangle.Height && members[i].vars.CollisionRectangle.Height <= (y1 + halfHeight)))
                        {
                            nw.Add(members[i]);
                        }
                        //ne
                        if (((x1 + halfLength) <= members[i].vars.CollisionRectangle.X && members[i].vars.CollisionRectangle.X <= x2)                 //top left 
                            && (y1 <= members[i].vars.CollisionRectangle.Y && members[i].vars.CollisionRectangle.Y <= (y1 + halfHeight))
                            || ((x1 + halfLength) <= members[i].vars.CollisionRectangle.Width && members[i].vars.CollisionRectangle.Width <= x2)      //top right
                            && (y1 <= members[i].vars.CollisionRectangle.Y && members[i].vars.CollisionRectangle.Y <= (y1 + halfHeight))
                            || ((x1 + halfLength) <= members[i].vars.CollisionRectangle.X && members[i].vars.CollisionRectangle.X <= x2)              //bottom left
                            && (y1 <= members[i].vars.CollisionRectangle.Height && members[i].vars.CollisionRectangle.Height <= (y1 + halfHeight))
                            || ((x1 + halfLength) <= members[i].vars.CollisionRectangle.Width && members[i].vars.CollisionRectangle.Width <= x2)      //bottom right
                            && (y1 <= members[i].vars.CollisionRectangle.Height && members[i].vars.CollisionRectangle.Height <= (y1 + halfHeight)))
                        {
                            ne.Add(members[i]);
                        }
                        //sw
                        if ((x1 <= members[i].vars.CollisionRectangle.X && members[i].vars.CollisionRectangle.X <= (x1 + halfLength))                 //top left 
                            && ((y1 + halfHeight) <= members[i].vars.CollisionRectangle.Y && members[i].vars.CollisionRectangle.Y <= y2)
                            || (x1 <= members[i].vars.CollisionRectangle.Width && members[i].vars.CollisionRectangle.Width <= (x1 + halfLength))      //top right
                            && ((y1 + halfHeight) <= members[i].vars.CollisionRectangle.Y && members[i].vars.CollisionRectangle.Y <= y2)
                            || (x1 <= members[i].vars.CollisionRectangle.X && members[i].vars.CollisionRectangle.X <= (x1 + halfLength))              //bottom left
                            && ((y1 + halfHeight) <= members[i].vars.CollisionRectangle.Height && members[i].vars.CollisionRectangle.Height <= y2)
                            || (x1 <= members[i].vars.CollisionRectangle.Width && members[i].vars.CollisionRectangle.Width <= (x1 + halfLength))      //bottom right
                            && ((y1 + halfHeight) <= members[i].vars.CollisionRectangle.Height && members[i].vars.CollisionRectangle.Height <= y2))
                        {
                            sw.Add(members[i]);
                        }
                        //se
                        if (((x1 + halfLength) <= members[i].vars.CollisionRectangle.X && members[i].vars.CollisionRectangle.X <= x2)                 //top left 
                            && ((y1 + halfHeight) <= members[i].vars.CollisionRectangle.Y && members[i].vars.CollisionRectangle.Y <= y2)
                            || ((x1 + halfLength) <= members[i].vars.CollisionRectangle.Width && members[i].vars.CollisionRectangle.Width <= x2)      //top right
                            && ((y1 + halfHeight) <= members[i].vars.CollisionRectangle.Y && members[i].vars.CollisionRectangle.Y <= y2)
                            || ((x1 + halfLength) <= members[i].vars.CollisionRectangle.X && members[i].vars.CollisionRectangle.X <= x2)              //bottom left
                            && ((y1 + halfHeight) <= members[i].vars.CollisionRectangle.Height && members[i].vars.CollisionRectangle.Height <= y2)
                            || ((x1 + halfLength) <= members[i].vars.CollisionRectangle.Width && members[i].vars.CollisionRectangle.Width <= x2)      //bottom right
                            && ((y1 + halfHeight) <= members[i].vars.CollisionRectangle.Height && members[i].vars.CollisionRectangle.Height <= y2))
                        {
                            se.Add(members[i]);
                        }
                    }
                    else
                    {
                        //Remove all non collidable members because they don't need to check for collisions
                        members.RemoveAt(i);
                    }
                    
                }
                
                //create the new QuadTrees (leaves)
                _nw = new QuadTree(nw, x1, y1, x1 + halfLength, y1 + halfHeight);
                _ne = new QuadTree(ne, x1 + halfLength, y1, x2, y1 + halfHeight);
                _sw = new QuadTree(sw, x1, y1 + halfHeight, x1 + halfLength, y2);
                _se = new QuadTree(se, x1 + halfLength, y1 + halfHeight, x2, y2);
            }
            else
            {
                //If we're done splitting, give our members a reference to us
                foreach (Entity ent in members)
                {
                    ent.vars.leaf = this;
                }
            }
        }
    }
}

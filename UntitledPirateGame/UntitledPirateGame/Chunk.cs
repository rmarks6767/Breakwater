using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    class Chunk
    {
        int x1, y1;
        int width, height;
        public List<Entity> members = new List<Entity>();
        private Chunk[,] adjChunks = new Chunk[3, 3];


        /// <summary>
        /// The chunk's world x1 coordinate
        /// </summary>
        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        /// <summary>
        /// The chunk's world y1 coordinate
        /// </summary>
        public int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        /// <summary>
        /// The chunk's world x2 coordinate
        /// </summary>
        public int X2
        {
            get { return x1 + width; }
        }

        /// <summary>
        /// The chunk's world y2 coordinate
        /// </summary>
        public int Y2
        {
            get { return y1 + height; }
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle(x1, y1, X2 - x1, Y2 - y1); }
        }

        public bool OnScreen
        {
            get
            {
                if (CoordinateMath.RectanglesOverLap(Screen.ScreenRectangle,Rectangle) || CoordinateMath.RectanglesOverLap(Rectangle, Screen.ScreenRectangle ))
                {
                    return true;
                }
                return false;
            }
        }

        public Chunk(int x1, int y1, int side)
        {
            this.x1 = x1;
            this.y1 = y1;
            width = side;
            height = width;
        }

        public void Add(Entity ent)
        {
            members.Add(ent);
        }
        public Entity At(int i)
        {
            if (members[i] != null)
            {
                return members[i];
            }
            return null;
        }
        public void Remove(Entity ent)
        {
            members.Remove(ent);
        }

        public void StoreAdjChunks(Chunk[,] chunks)
        {
            
        }
    }
}

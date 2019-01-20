using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledPirateGame
{
    class Chunk
    {
        int x1, y1;
        const int width = 100;
        const int height = width;
        public List<Entities> members = new List<Entities>();


        /// <summary>
        /// The screen's world x1 coordinate
        /// </summary>
        int X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        /// <summary>
        /// The screen's world y1 coordinate
        /// </summary>
        int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        /// <summary>
        /// The screen's world x2 coordinate
        /// </summary>
        int X2
        {
            get { return x1 + width; }
        }

        /// <summary>
        /// The sreen's world y2 coordinate
        /// </summary>
        int Y2
        {
            get { return y1 + height; }
        }

        public Chunk(int x1,int y1)
        {
            this.x1 = x1;
            this.y1 = y1;

        }

    }
}

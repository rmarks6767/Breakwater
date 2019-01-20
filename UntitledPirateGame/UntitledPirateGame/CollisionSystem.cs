using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledPirateGame
{
    class CollisionSystem
    {
        // list of all the entities that exist in the room
        private static List<Entities> entities;
        private int numChunks;

        public List<Entities> Entities { get { return entities; } }

        public CollisionSystem(int numChunks)
        {
            entities = new List<Entities>();
            this.numChunks = numChunks;
        }
    }
}

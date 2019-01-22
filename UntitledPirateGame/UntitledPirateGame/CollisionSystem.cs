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
        private static List<Entity> entities;
        private int numChunks;

        public List<Entity> Entity { get { return entities; } }

        public CollisionSystem(int numChunks)
        {
            entities = new List<Entity>();
            this.numChunks = numChunks;
        }
    }
}

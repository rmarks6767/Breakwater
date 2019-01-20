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
        private List<Entities> entities = new List<Entities>();

        // all entities will add themselves to the list to be able to check the collisions
        public void AddEntity(Entities s) { entities.Add(s); }

        // create the first node that starts to split all of the stuff
        // the two hundreds will be changed to signify the different chunks that are in the world
        Node node = new Node(entities, 0, 100, 0, 100);
    }
    class Node
    {
        // All four boxes 
        private List<Entities> nw;
        private List<Entities> ne;
        private List<Entities> sw;
        private List<Entities> se;

        //properties for the boxes
        public List<Entities> NW { get { return nw; } }
        public List<Entities> NE { get { return ne; } }
        public List<Entities> SW { get { return sw; } }
        public List<Entities> SE { get { return se; } }

        public Node(List<Entities> boxes, double x1, double x2, double y1, double y2)
        {
            if (boxes.Count > 1)
            {
                for (int i = 0; i < boxes.Count; i++)
                {
                    //nw
                    if ()
                    {

                    }

                    //ne

                    //sw

                    //se
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UntitledPirateGame
{
    class FindPath
    {
        private Vector2 startPoint;
        private Vector2 endPoint;
        private Grid grid;
        private List<Vector2> checkedNodes;
        private List<Vector2> nodesToCheck;


        /// <summary>
        /// This class will ultimately return the path at which an npc has to take to get to a given spot
        /// </summary>
        /// <param name="startPoint">Where the npc is at the start time</param>
        /// <param name="endPoint">Where the npc wants to go</param>
        /// <param name="grid">The main grid that contains all of the points that exist on the screen / world.  Contains the points that nodes that need to be checked</param>
        public FindPath(Vector2 startPoint, Vector2 endPoint, Grid grid)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.grid = grid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="checkedNodes"></param>
        /// <param name="nodesToCheck"></param>
        private void AStar(Grid grid, List<Vector2> checkedNodes, List<Vector2> nodesToCheck)
        {

        }






    }
}

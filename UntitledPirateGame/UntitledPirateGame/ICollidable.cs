using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledPirateGame
{
    /// <summary>
    /// An interface given to collidable objects
    /// </summary>
    interface ICollidable
    {
        bool HasCollision
        {
            get;
            set;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledPirateGame
{
    interface ICollidable
    {
        bool HasCollision
        {
            get;
            set;
        }

        List<ICollidable> IsColliding();

    }
}

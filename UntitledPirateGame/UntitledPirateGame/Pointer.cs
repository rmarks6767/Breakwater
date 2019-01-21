using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace UntitledPirateGame
{
    static class Pointer
    {
        public static Vector2 Position
        {
            get { return new Vector2(Mouse.GetState().X, Mouse.GetState().Y); }
        }

        public static float GetAngleBetween(Entities entity)
        {
            if(entity.vars.originX >= Position.X)
            {
                return (float)Math.Atan((Position.Y - entity.vars.originY) / (Position.X - entity.vars.originX));
            }
            else
            {
                return (float)(Math.Atan((Position.Y - entity.vars.originY) / (Position.X - entity.vars.originX)) + Math.PI);
            }
        }
    }
}

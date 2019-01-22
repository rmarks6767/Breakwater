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

        public static float GetAngleBetween(Entity entity)
        {
            if(entity.vars.Rectangle.Center.X >= Position.X)
            {
                return (float)Math.Atan((Position.Y - entity.vars.Rectangle.Center.Y) / (Position.X - entity.vars.Rectangle.Center.X));
            }
            else
            {
                return (float)(Math.Atan((Position.Y - entity.vars.Rectangle.Center.Y) / (Position.X - entity.vars.Rectangle.Center.X)) + Math.PI);
            }
        }
    }
}

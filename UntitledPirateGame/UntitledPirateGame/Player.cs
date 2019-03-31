using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UntitledPirateGame
{
    class Player : Entity, IMovable
    {
        private int speed;

        public Player(int speed, int width, int height, int x, int y, int elevation, float rotation, bool isVisible, Texture2D sprite) 
            : base(width, height, x, y, elevation, rotation, isVisible, sprite) { this.speed = speed; }

        /// <summary>
        /// Moves to the given coordinates if there is no collidable object impeding movement
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y Position</param>
        public void Move(int x, int y)
        {
            for (int i = 0; i < vars.leaf.members.Count; i++)
            {
                //If the point isn't contained, move to the point
                if (!vars.leaf.members[i].vars.CollisionRectangle.Contains(x,y))
                {
                    vars.DrawingVector.X = x;
                    vars.DrawingVector.Y = y;
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {


                vars.DrawingVector.Y -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                //Move((int)vars.DrawingVector.X, (int)vars.DrawingVector.Y - (int)(speed * gameTime.ElapsedGameTime.TotalSeconds));

            }
            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vars.DrawingVector.Y += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                //Move((int)vars.DrawingVector.X, (int)vars.DrawingVector.Y + (int)(speed * gameTime.ElapsedGameTime.TotalSeconds));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vars.DrawingVector.X -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                //Move((int)vars.DrawingVector.X - (int)(speed * gameTime.ElapsedGameTime.TotalSeconds), (int)vars.DrawingVector.Y);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vars.DrawingVector.X += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                //Move((int)vars.DrawingVector.X + (int)(speed * gameTime.ElapsedGameTime.TotalSeconds), (int)vars.DrawingVector.Y);
            }

            vars.rotation = Pointer.GetAngleBetween(this);
        }
    }
}

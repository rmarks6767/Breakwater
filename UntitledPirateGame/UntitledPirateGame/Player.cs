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
    class Player : Entities
    {
        private int speed;

        public Player(int speed, int width, int height, int originX, int originY, int elevation, float rotation, bool isVisible, Texture2D sprite) 
            : base(width, height, originX, originY, elevation, rotation, isVisible, sprite) { this.speed = speed; }

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {
                vars.originY -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vars.originY += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vars.originX -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vars.originX += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            vars.rotation = Pointer.GetAngleBetween(this);
        }
    }
}

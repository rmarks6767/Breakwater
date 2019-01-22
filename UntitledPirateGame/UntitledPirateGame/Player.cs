﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UntitledPirateGame
{
    class Player : Entity
    {
        private int speed;

        public Player(int speed, int width, int height, int x, int y, int elevation, float rotation, bool isVisible, Texture2D sprite) 
            : base(width, height, x, y, elevation, rotation, isVisible, sprite) { this.speed = speed; }

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {
                vars.Rectangle.Y -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vars.Rectangle.Y += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vars.Rectangle.X -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vars.Rectangle.X += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            vars.rotation = Pointer.GetAngleBetween(this);
        }
    }
}

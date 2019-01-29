using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledPirateGame
{
    class UIComponent
    {
        private Rectangle drawingRect, sourceRect;
        private Texture2D background;
        private int elevation;
        protected SpriteBatch spriteBatch;

        public Rectangle DrawingRectangle
        {
            get { return drawingRect; }
        }
        public Rectangle SourceRectangle
        {
            get { return sourceRect; }
        }
        public Texture2D Background
        {
            get { return background; }
        }
        public int Elevation
        {
            get { return elevation; }
        }

        public UIComponent(SpriteBatch sb, Rectangle drawingRectangle, Texture2D backgroundTexture, int _elevation)
        {
            drawingRect = drawingRectangle;
            background = backgroundTexture;
            if (background != null)
            {
                sourceRect = new Rectangle(0, 0, Background.Width, Background.Height);
            }
            elevation = _elevation;
            spriteBatch = sb;
        }

        public virtual void Draw()
        {
            if (background != null)
            {
                spriteBatch.Draw(texture: background, destinationRectangle: drawingRect, sourceRectangle: sourceRect);
            }
        }
    }
}

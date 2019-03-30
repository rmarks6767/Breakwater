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
        private Rectangle drawingRect;
        private Texture2D background;
        private int elevation;

        public Rectangle DrawingRectangle
        {
            get { return drawingRect; }
        }
        public Texture2D Background
        {
            get { return background; }
        }
        public int Elevation
        {
            get { return elevation; }
        }

        public UIComponent(Rectangle drawingRectangle, Texture2D backgroundTexture, int _elevation)
        {
            drawingRect = drawingRectangle;
            background = backgroundTexture;
            elevation = _elevation;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            if (background != null)
            {
                sb.Draw(texture: background, destinationRectangle: drawingRect);
            }
        }

        public virtual void Update() {  }

        public void ChangePos(Vector2 newPos)
        {
            drawingRect = new Rectangle((int)newPos.X, (int)newPos.Y, drawingRect.Width, drawingRect.Height);
        }
    }
}

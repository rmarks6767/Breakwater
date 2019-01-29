using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledPirateGame
{
    class UIText : UIComponent
    {
        private SpriteFont font;
        private String text;
        private Vector2 pos;
        private Color color;

        public UIText(SpriteBatch sb, Rectangle drawingRectangle, Texture2D backgroundTexture, int elevation, SpriteFont _font, Color _color) : base(sb, drawingRectangle, backgroundTexture, elevation)
        {
            font = _font;
            text = "";
            color = _color;
            pos = new Vector2(drawingRectangle.X, drawingRectangle.Y);
        }
        public UIText(SpriteBatch sb, Rectangle drawingRectangle, Texture2D backgroundTexture, int elevation, SpriteFont _font, String _text, Color _color) : base(sb, drawingRectangle, backgroundTexture, elevation)
        {
            font = _font;
            text = _text;
            color = _color;
            pos = new Vector2(drawingRectangle.X, drawingRectangle.Y);
        }

        public void SetText(String _text)
        {
            text = _text;
        }

        public override void Draw()
        {
            spriteBatch.DrawString(spriteFont: font, text: text, position: pos, color: color);
            base.Draw();
        }
    }
}

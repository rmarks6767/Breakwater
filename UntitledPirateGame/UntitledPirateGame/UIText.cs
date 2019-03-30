using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledPirateGame
{
    enum TextAlign
    {
        Center,
        Left,
        Right
    }

    class UIText : UIComponent
    {
        private SpriteFont font;
        private String text;
        private Vector2 pos, origin;
        protected Color color;
        private TextAlign align;

        public UIText(Rectangle drawingRectangle, Texture2D backgroundTexture, int elevation, SpriteFont _font, Color _color, TextAlign _align) : base(drawingRectangle, backgroundTexture, elevation)
        {
            font = _font;
            text = "";
            color = _color;
            align = _align;
            switch(align)
            {
                case TextAlign.Center:
                    origin = new Vector2(font.MeasureString(text).X / 2, 0);
                    break;

                case TextAlign.Left:
                    origin = new Vector2(0, 0);
                    break;

                case TextAlign.Right:
                    origin = new Vector2(font.MeasureString(text).X, 0);
                    break;
            }
            pos = new Vector2(drawingRectangle.X, drawingRectangle.Y + font.MeasureString(text).Y / 2);
        }
        public UIText(String _text, Rectangle drawingRectangle, Texture2D backgroundTexture, int elevation, SpriteFont _font, Color _color, TextAlign _align) : base(drawingRectangle, backgroundTexture, elevation)
        {
            font = _font;
            text = _text;
            color = _color;
            align = _align;
            switch (align)
            {
                case TextAlign.Center:
                    origin = new Vector2(font.MeasureString(text).X / 2, 0);
                    break;

                case TextAlign.Left:
                    origin = new Vector2(0, 0);
                    break;

                case TextAlign.Right:
                    origin = new Vector2(font.MeasureString(text).X, 0);
                    break;
            }
            pos = new Vector2(drawingRectangle.X, drawingRectangle.Y + font.MeasureString(text).Y / 2);
        }

        public void SetText(String _text)
        {
            text = _text;
            switch (align)
            {
                case TextAlign.Center:
                    origin = new Vector2(font.MeasureString(text).X / 2, 0);
                    break;

                case TextAlign.Left:
                    origin = new Vector2(0, 0);
                    break;

                case TextAlign.Right:
                    origin = new Vector2(font.MeasureString(text).X, 0);
                    break;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.DrawString(font, text, pos, color, 0, origin, 1, SpriteEffects.None, Elevation);
        }

        public override void Update()
        {
            pos = new Vector2(DrawingRectangle.X, DrawingRectangle.Y + font.MeasureString(text).Y / 2);
        }
    }
}

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
    public delegate void OnClickDelegate();
    public delegate void OnHoverDelegate();

    class UIButton : UIText
    {
        private event OnClickDelegate OnClick;
        private event OnHoverDelegate OnHover;
        private Color idleColor, hoverColor;
        private bool isHover;

        public UIButton(OnClickDelegate onClick, OnHoverDelegate onHover, String text, Rectangle drawingRectangle, Texture2D background, int elevation, SpriteFont font, Color color, Color _hoverColor, TextAlign align) : base(text, drawingRectangle, background, elevation, font, color, align)
        {
            OnClick += onClick;
            OnHover += onHover;
            hoverColor = _hoverColor;
            idleColor = color;
        }

        public UIButton(OnClickDelegate[] onClicks, OnHoverDelegate[] onHovers, String text, Rectangle drawingRectangle, Texture2D background, int elevation, SpriteFont font, Color color, Color _hoverColor, TextAlign align) : base(text, drawingRectangle, background, elevation, font, color, align)
        {
            foreach (OnClickDelegate onClick in onClicks)
            {
                OnClick += onClick;
            }
            foreach (OnHoverDelegate onHover in onHovers)
            {
                OnHover += onHover;
            }
            hoverColor = _hoverColor;
            idleColor = color;
        }

        public UIButton(OnClickDelegate onClick, OnHoverDelegate onHover, Rectangle drawingRectangle, Texture2D background, int elevation, SpriteFont font, Color color, Color _hoverColor, TextAlign align) : base(drawingRectangle, background, elevation, font, color, align)
        {
            OnClick += onClick;
            OnHover += onHover;
            hoverColor = _hoverColor;
            idleColor = color;
        }

        public UIButton(OnClickDelegate[] onClicks, OnHoverDelegate[] onHovers, Rectangle drawingRectangle, Texture2D background, int elevation, SpriteFont font, Color color, Color _hoverColor, TextAlign align) : base(drawingRectangle, background, elevation, font, color, align)
        {
            foreach(OnClickDelegate onClick in onClicks)
            {
                OnClick += onClick;
            }
            foreach(OnHoverDelegate onHover in onHovers)
            {
                OnHover += onHover;
            }
            hoverColor = _hoverColor;
            idleColor = color;
        }

        public override void Update()
        {
            if(DrawingRectangle.Contains(Mouse.GetState().Position))
            {
                OnHover();
                isHover = true;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    OnClick();
                }
            }
            else
            {
                isHover = false;
            }
            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            if(isHover)
            {
                color = hoverColor;
            }
            else
            {
                color = idleColor;
            }
            base.Draw(sb);
        }
    }
}

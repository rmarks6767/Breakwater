using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledPirateGame
{
    class UIPanel : UIComponent
    {
        private List<UIComponent> children;

        public UIPanel(Rectangle drawingRectangle, Texture2D background, int elevation) : base(drawingRectangle, background, elevation)
        {
            children = new List<UIComponent>();
        }

        public void AddComponent(UIComponent component)
        {
            component.ChangePos(new Vector2(component.DrawingRectangle.X + DrawingRectangle.X, component.DrawingRectangle.Y + DrawingRectangle.Y));
            children.Add(component);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            foreach(UIComponent component in children)
            {
                component.Draw(sb);
            }
        }

        public override void Update()
        {
            base.Update();
            foreach(UIComponent component in children)
            {
                component.Update();
            }
        }
    }
}

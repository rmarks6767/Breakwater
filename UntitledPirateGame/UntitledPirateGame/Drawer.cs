using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledPirateGame
{
    class Drawer
    {
        public void Draw(SpriteBatch spriteBatch, List<Entity> onScreenEntity)
        {
            List<Entity> sortedEntity = MergeSort(onScreenEntity);

            spriteBatch.Begin();
            foreach(Entity entity in sortedEntity)
            {
                //Thanks Aidan
                Vector2 toDraw = new Vector2(entity.vars.DrawingVector.X - Screen.X + Screen.ScreenWidth/2, entity.vars.DrawingVector.Y - Screen.Y + Screen.ScreenHeight/2);
                spriteBatch.Draw(
                    texture: entity.vars.sprite,
                    position:toDraw,
                    rotation: entity.vars.rotation,
                    origin: new Vector2(entity.vars.sprite.Width/2, entity.vars.sprite.Height / 2)
                    );
            }
            spriteBatch.End();
        }

        private List<Entity> MergeSort(List<Entity> list)
        {
            List<Entity> right = new List<Entity>();
            List<Entity> left = new List<Entity>();

            for(int i = 0; i < list.Count; i++)
            {
                if(i < list.Count / 2)
                {
                    left.Add(list.ElementAt(i));
                }
                else
                {
                    right.Add(list.ElementAt(i));
                }
            }

            if(left.Count > 1)
            {
                left = MergeSort(left);
            }
            if(right.Count > 1)
            {
                right = MergeSort(right);
            }

            list = Merge(left, right);

            return list;
        }

        private List<Entity> Merge(List<Entity> left, List<Entity> right)
        {
            List<Entity> result = new List<Entity>();

            int countL = 0, countR = 0;

            while(countL < left.Count && countR < right.Count)
            {
                if(left.ElementAt(countL).vars.elevation < right.ElementAt(countR).vars.elevation)
                {
                    result.Add(left.ElementAt(countL));
                    countL++;
                }
                else
                {
                    result.Add(right.ElementAt(countR));
                    countR++;
                }
            }
            while(countL < left.Count)
            {
                result.Add(left.ElementAt(countL));
                countL++;
            }
            while (countR < right.Count)
            {
                result.Add(right.ElementAt(countR));
                countR++;
            }

            return result;
        }
    }
}

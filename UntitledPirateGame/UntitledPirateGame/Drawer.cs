﻿using System;
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
        public void Draw(SpriteBatch spriteBatch, List<Entities> onScreenEntities)
        {
            List<Entities> sortedEntities = MergeSort(onScreenEntities);

            spriteBatch.Begin();
            foreach(Entities entity in sortedEntities)
            {
                spriteBatch.Draw(texture: entity.entityVariables.texture, destinationRectangle: entity.entityVariables.rect, rotation: entity.entityVariables.rotation, origin: new Vector2(entity.entityVariables.rect.Width / 2, entity.entityVariables.rect.Height / 2));
            }
            spriteBatch.End();
        }

        private List<Entities> MergeSort(List<Entities> list)
        {
            List<Entities> right = new List<Entities>();
            List<Entities> left = new List<Entities>();

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

        private List<Entities> Merge(List<Entities> left, List<Entities> right)
        {
            List<Entities> result = new List<Entities>();

            int countL = 0, countR = 0;

            while(countL < left.Count && countR <= right.Count)
            {
                if(left.ElementAt(countL).entityVariables.elvation < right.ElementAt(countR).entityVariables.elvation)
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
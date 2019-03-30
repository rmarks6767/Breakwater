using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledPirateGame
{
    class Canvas
    {
        private List<UIComponent> components;

        public Canvas()
        {
            components = new List<UIComponent>();
        }

        public void AddComponent(UIComponent component)
        {
            components.Add(component);
        }

        public List<UIComponent> GetUIComponents()
        {
            components = MergeSort(components);
            return components;
        }

        public void Update()
        {
            foreach(UIComponent component in components)
            {
                component.Update();
            }
        }

        private List<UIComponent> MergeSort(List<UIComponent> list)
        {
            List<UIComponent> right = new List<UIComponent>();
            List<UIComponent> left = new List<UIComponent>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i < list.Count / 2)
                {
                    left.Add(list.ElementAt(i));
                }
                else
                {
                    right.Add(list.ElementAt(i));
                }
            }

            if (left.Count > 1)
            {
                left = MergeSort(left);
            }
            if (right.Count > 1)
            {
                right = MergeSort(right);
            }

            list = Merge(left, right);

            return list;
        }

        private List<UIComponent> Merge(List<UIComponent> left, List<UIComponent> right)
        {
            List<UIComponent> result = new List<UIComponent>();

            int countL = 0, countR = 0;

            while (countL < left.Count && countR < right.Count)
            {
                if (left.ElementAt(countL).Elevation < right.ElementAt(countR).Elevation)
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
            while (countL < left.Count)
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

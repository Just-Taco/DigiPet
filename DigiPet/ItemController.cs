using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
       
    class ItemController
    {
        public List<IItem> Items = new();

        public ItemController()
        {
            Items.Add(new Food("Apple", 10, 30));
            Items.Add(new Food("Beef", 55, 80));
            Items.Add(new Food("Fisk", 20, 40));
            Items.Add(new Potion("Potion", 50, 40));
            Items.Add(new Potion("Big-Potion", 60, 100));
        }

        public IItem? Find(string name)
        {
            foreach (IItem item in Items)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public IItem RandomItem()
        {
            return Items[RNG.randomNumber(0, Items.Count)];
        }
    }
}

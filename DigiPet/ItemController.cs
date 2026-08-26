using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
       
    class ItemController
    {
        public List<Item> Items = new();

        public ItemController()
        {
            Items.Add(new Item("Apple", 10, 0, 30));
            Items.Add(new Item("Steak", 25, 5, 60));
            Items.Add(new Item("Potion", 50, 40, 0));
            Items.Add(new Item("Elixir", 120, 100, 50));
        }

        public Item? Find(string name)
        {
            foreach (Item item in Items)
            {
                if (item.Name.ToLower() == name.ToLower())
                    return item;
            }
            return null;
        }
    }
}

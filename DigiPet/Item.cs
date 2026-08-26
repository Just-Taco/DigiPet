using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DigiPet
{
    class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Heal { get; set; }
        public int Food { get; set; }

        public Item() { }

        public Item(string name, int price, int heal, int food)
        {
            Name = name;
            Price = price;
            Heal = heal;
            Food = food;
        }

        public void Use(DigiPet target)
        {
            target.Health = Math.Clamp(target.Health + Heal, 0, 100);
            target.Hunger = Math.Clamp(target.Hunger + Food, 0, 100);
            target.Happiness = Math.Clamp(target.Happiness + 5, 0, 100);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    class Food : IConsumable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Hunger { get; set; }

        public Food(string name, int price, int hunger)
        {
            Name = name;
            Price = price;
            Hunger = hunger;
        }

        public string Use(DigiPet target)
        {
            target.Hunger = Math.Clamp(target.Hunger + Hunger, 0, 100);
            target.Happiness = Math.Clamp(target.Happiness + 5, 0, 100);
            return $"{target.Name} ate {Name}";
        }

        public IItem Copy() => new Food(Name, Price, Hunger);
    }
}
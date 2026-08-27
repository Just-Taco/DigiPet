using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    class Potion : IConsumable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Heal { get; set; }

        public Potion(string name, int price, int heal)
        {
            Name = name;
            Price = price;
            Heal = heal;
        }

        public string Use(DigiPet target)
        {
            target.Health = Math.Clamp(target.Health + Heal, 0, 100);
            target.Happiness = Math.Clamp(target.Happiness + 5, 0, 100);
            return $"{target.Name} drank {Name} and healed {Heal} HP";
        }

        public IItem Copy() => new Potion(Name, Price, Heal);
    }
}

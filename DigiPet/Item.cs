using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DigiPet
{
    class Item
    {
        public readonly string _name;
        public readonly int _price;
        public int _heal;
        public int _food;

        public Item(string name, int price, int heal, int food)
        {
            this._name = name;
            this._price = price;
            this._heal = heal;
            this._food = food;
        }

        public void Use(DigiPet target)
        {
            target.Health += _heal;
            if (target.Health > 100) target.Health = 100;
            target.Hunger += _food;
            if (target.Hunger > 100) target.Hunger = 100;
            target.Happiness += 5;
            if (target.Happiness > 100) target.Happiness = 100;
        }
    }
}

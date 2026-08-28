using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DigiPet
{

    class Enemy : IFightable
    {
        private int _health;
        public string Name { get; }
        public bool IsAlive => _health > 0;
        private int _atkDamage;

        public Enemy()
        {
            this.Name = RNG.randomAnimalName();
            this._health = RNG.randomNumber(20, 70);
            this._atkDamage = RNG.randomNumber(5, 10);
        }



        public int Attack(IFightable target) => _atkDamage;

        public void TakeDamage(int amount)
        {
            _health -= amount;
        }
    }
}

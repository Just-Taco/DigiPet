using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{

    class Enemy : IFightable
    {
        private int _health;
        private string _name;
        private int _atkDamage;

        public Enemy()
        {
            this._name = RNG.randomAnimalName();
            this._health = RNG.randomNumber(20, 70);
            this._atkDamage = RNG.randomNumber(2, 5);
        }

        public int Attack(IFightable target)
        {
            return 5;
        }

        public void TakeDamage(int amount)
        {

        }
    }
}

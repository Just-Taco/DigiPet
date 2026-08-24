using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    class DigiPet : IFightable
    {
        enum PetStatus
        {
            Happy,
            Mad,
            Sad,
        }
        private string _name;
        private DateTime _born;
        private int _hunger;
        private int _health;
        private int _happiness;
        private PetStatus _status;
        private Inventory _inventory;

        public DigiPet(string name)
        {
            this._name = name;
            this._born = DateTime.Now;
            this._hunger = 100;
            this._health = 100;
            this._happiness = 100;
            this._status = PetStatus.Happy;
            this._inventory = new();
        }

        public void Feed(Item food)
        {

        }

        public void Pet()
        {
            this._happiness += 10;
        }

        public void CleanUp()
        {
            this._inventory.;
        }

        public int Attack(IFightable target)
        {
            // Item logic ? Add
            const int damage = 10;
            return damage;
        }

        public void TakeDamage(int amount)
        {
            this._health -= amount;
        }

        public void Tick()
        {
            this._happiness -= 1;
            if (this._hunger <= 0)
            {
                if (this._health <= 0)
                {
                    // die (Use event?)
                }
                this._health -= 1;
            }
            this._hunger -= 1;
        }
    }
}

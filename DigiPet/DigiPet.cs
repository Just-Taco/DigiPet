using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    class DigiPet : IFightable
    {

        public string Name { get; set; }
        public DateTime Born { get; set; }
        public int Hunger { get; set; }
        public int Health { get; set; }
        public int Happiness { get; set; }
        public Inventory Inventory { get; set; } = new();

        public DigiPet(string name)
        {
            this.Name = name;
            this.Born = DateTime.Now;
            this.Hunger = 100;
            this.Health = 100;
            this.Happiness = 100;
        }

        public string Pet()
        {
            this.Happiness += 10;
            return "mis mis";
        }

        public void CleanUp()
        {
            this.Inventory.ClearInventory();
        }

        public int Attack(IFightable target)
        {
            // Item logic ? Add
            const int damage = 10;
            return damage;
        }

        public void TakeDamage(int amount)
        {
            this.Health -= amount;
        }

        public void Tick()
        {
            Thread.Sleep(2000);
            this.Happiness -= 1;
            if (this.Hunger <= 0)
            {
                if (this.Health <= 0)
                {
                    // die (Use event?)
                }
                this.Health -= 1;
            }
            this.Hunger -= 1;
        }
    }
}

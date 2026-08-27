using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    class DigiPet : IFightable
    {

        public string Name { get; set; }
        public bool IsAlive { get; }
        public DateTime Born { get; set; }
        public int Hunger { get; set; }
        public int Health { get; set; }
        public int Happiness { get; set; }
        public int Coins { get; set; } = 100;
        public IEquippable? Weapon { get; set; }
        public IEquippable? Armor { get; set; }
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
            return 10 + (Weapon?.Damage ?? 0);
        }

        public void TakeDamage(int amount)
        {
            int blocked = Armor?.Armor ?? 0;
            Health -= Math.Max(1, amount - blocked);
        }

        public void Tick()
        {
            while (true)
            {
                Thread.Sleep(10000);
                Happiness -= 1;
                Hunger -= 1;
                if (Hunger <= 0)
                {
                    Health -= 1;
                    if (Health <= 0)
                    {
                        // die
                    }
                }
            }
        }
    }
}

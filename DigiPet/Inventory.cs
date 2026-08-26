using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace DigiPet
{
    class Inventory
    {
        private List<Item> Items { get; set; } = new();
        //Consumab
        //Healing items
        //Food items
        //weapon items
        //Armor

        public string UseItem(Item item, DigiPet pet, ItemController items)
        {
            if (!Items.Contains(item))
            {
                return "You dont have that";
            }

            item.Use(pet);
            Items.Remove(item);
            return $"Used {item}";
        }

        public void AddItem(Item item)
        {
            this.Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            this.Items.Remove(item);
        }

        public void ClearInventory()
        {
            // CHECK THIS (does it delete or just create more and more lists??)
            this.Items = new();
        }

    }
}

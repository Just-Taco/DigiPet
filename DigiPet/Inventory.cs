using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace DigiPet
{
    class Inventory
    {
        public List<IItem> Items { get; set; } = new();
        //Consumab
        //Healing items
        //Food items
        //weapon items
        //Armor

        public string UseItem(IItem item, DigiPet pet)
        {
            if (!Items.Contains(item))
            {
                return "You dont have that";
            }

            if (item is not IUseable useable)
            {
                return $"You cant use {item.Name} like that"; 
            }

            string result = useable.Use(pet);

            if (item is IConsumable)
            {
                Items.Remove(item);
            }

            return result;
        }

        public void AddItem(IItem item)
        {
            this.Items.Add(item);
        }

        public void RemoveItem(IItem item)
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

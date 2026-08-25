using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace DigiPet
{
    class Inventory
    {
        private List<Item> _items = new();
        private DigiPet _pet;

        public Inventory(DigiPet Pet)
        {
            this._pet = Pet;
        }

        public void UseItem(Item item)
        {
            item.Use(_pet);
        }

        public void AddItem(Item item)
        {
            this._items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            this._items.Remove(item);
        }

        public void ClearInventory()
        {
            // CHECK THIS (does it delete or just create more and more lists??)
            this._items = new();
        }

    }
}

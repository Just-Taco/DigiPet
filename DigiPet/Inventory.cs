using System;
using System.Collections.Generic;
using System.Text;

namespace DigiPet
{
    class Inventory
    {
        private List<Item> _items = new();

        public void UseItem(Item item)
        {

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

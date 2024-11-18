using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class ItemService : IItemService
    {
        /*
         * As I'm not connected to a DB, I chose to store the vending machine's inventory as a dictionary with a single item.
         * I felt this would allow for usage with all basic operations outlined in the use case diagram without overimplementing what's needed for the problem.
         * This service handles item access and modification to item stock.
        */
        private Dictionary<int, Item> _inventory = new Dictionary<int, Item>
        {
            {1, new Item(1, "Chips", 3, 2) }
        };

        public bool CheckInventory(int id)
        {
            if (_inventory.ContainsKey(id))
            {
                Item selected = _inventory[id];
                return selected.Amount > 0;
            } else
            {
                return false;
            }
        }

        public Item GetItem(int id)
        {
            Item selected = _inventory.ContainsKey(id) ? _inventory[id] : null;
            if (selected != null)
            {
                Console.WriteLine($"Selected {selected.Name} priced at ${selected.Price}.");
            }
            return selected;
        }

        public void ReduceStock(int id)
        {
            Item selected = _inventory[id];
            selected.Amount -= 1;
        }

    }
}

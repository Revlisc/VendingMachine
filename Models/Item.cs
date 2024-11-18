using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    /*
     * The item class represents a vending machine item. It stores the minimum data needed to represent a "slot" in a vending machine.
     * 
    */
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Item(int id, string name, int amount, double price)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Price = price;
        }
    }
}

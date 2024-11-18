using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class DispenseService : IDispenseService
    {
        /*
         * Service with isolated methods to handle outputting values to the user. Allows for better separation of concerns and follows single responsibility principle. 
        */
        public void DispenseItem(Item item)
        {
            string itemName = item.Name;
            Console.WriteLine($"Please take your {itemName}");
        }

        public void DispenseChange(double amount)
        {
            if (amount > 0)
            {
                Console.WriteLine($"Please take your change of ${amount}");
            }
        }
    }
}

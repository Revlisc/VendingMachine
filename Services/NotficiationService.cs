using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;

namespace VendingMachine.Services
{
    public class NotficiationService : INotification
    {
        // This service handles notification to an admin when the stock is low. This was mentioned in the documentation, so I took an educated guess that this would
        // be the main issue to notify an admin about. I created this as it's own class to allow for potential additions and modifications in the future
        // should we want to add additional notifications.
        public void Notify(int id)
        {
            Console.WriteLine($"ERROR CODE 1: Inventory is low for item: {id}");
        }
    }
}

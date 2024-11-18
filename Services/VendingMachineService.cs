using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    /*
     * Serves as the main "mediator" for the application and uses the other services to implement functionality.
     * Outlines the basic functionalities required by the machine then uses DI to implement said functionality.
     * 
     */
    public class VendingMachineService : IVendingMachine
    {
        private readonly IItemService _itemService;
        private readonly IDispenseService _dispenseService;
        private readonly IPaymentService _paymentService;
        private readonly INotification _notification;

        private int amountPaid { get; set; }
        private double amountOwed { get; set; }
        private Item selectedItem { get; set; }

        public VendingMachineService(IPaymentService payment, IDispenseService dispense, IItemService itemService, INotification notification)
        {
            _paymentService = payment;
            _dispenseService = dispense;
            _itemService = itemService;
            _notification = notification;
        }

        public bool SelectItem(int id)
        {
            if (_itemService.CheckInventory(id))
            {
                var item = _itemService.GetItem(id);
                if (item == null)
                {
                    Console.WriteLine("Selected Item is out of stock.");
                    return false;
                }
                amountOwed = item.Price;
                selectedItem = item;
                return true;
            } else
            {
                Console.WriteLine("This item is not available");
                return false;
            }
        }

        public bool InputCash(int amount)
        {
            if (amount < amountOwed)
            {
                Console.WriteLine("Please insert the correct payment amount.");
                ReturnInput(amount);
                return false;
            } else
            {
                amountPaid = amount;
                return true;
            }
        }

        public void Dispense()
        {
            if (amountOwed > amountPaid)
            {
                Console.WriteLine("Please insert the correct payment amount.");
                ReturnInput(amountPaid);
            }

            double change = _paymentService.CalculateChange(amountPaid, amountOwed);
            _dispenseService.DispenseItem(selectedItem);
            _itemService.ReduceStock(selectedItem.Id);

            if (selectedItem.Amount == 1)
            {
                _notification.Notify(selectedItem.Id);
            }

            if (change > 0)
            {
                _dispenseService.DispenseChange(change);
            }

            amountOwed = 0;
            selectedItem = null;
            amountPaid = 0;
        }

        public void ReturnInput(int amount)
        {
            if (amount > 0)
            {
                _paymentService.ReturnInput(amount);

            }
        }
    }
}

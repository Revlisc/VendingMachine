using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IDispenseService
    {
        void DispenseItem(Item item);
        void DispenseChange(double amount);
    }
}

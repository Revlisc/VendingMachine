using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Interfaces
{
    public interface IVendingMachine
    {
        bool SelectItem(int id);
        bool InputCash(int amount);
        void Dispense();
        void ReturnInput(int amount);
    }
}

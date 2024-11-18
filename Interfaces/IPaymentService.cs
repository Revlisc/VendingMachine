using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Interfaces
{
    public interface IPaymentService
    {
        bool ValidateInput(int input);
        double CalculateChange(int input, double itemPrice);
        void ReturnInput(int amount);
    }
}

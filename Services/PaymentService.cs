using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;

namespace VendingMachine.Services
{
    public class PaymentService : IPaymentService
    {
        /*
         * Serves as a means to handle basic error handling to validate the user's input and calculate change. Allows for sep. of concerns and open to addition in the future.
         */
        public bool ValidateInput(int input)
        {
            return input > 0 && input % 1 == 0;
        }

        public double CalculateChange(int input, double itemPrice)
        {
            return input - itemPrice;
        }

        public void ReturnInput(int amount)
        {
            Console.WriteLine($"There was a problem processing your request. Returning ${amount}");
        }
    }
}

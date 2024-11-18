using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register services with the DI container
                    services.AddScoped<IItemService, ItemService>();
                    services.AddSingleton<IPaymentService, PaymentService>();
                    services.AddScoped<IDispenseService, DispenseService>();
                    services.AddScoped<IVendingMachine, VendingMachineService>();
                    services.AddScoped<INotification, NotficiationService>();

                    // Add the main application entry point
                    services.AddScoped<App>();
                })
                .Build();

            // Start the application
            var app = host.Services.GetRequiredService<App>();
            app.Run();
        }

        // Basic logic loop for running the application. Utilizes the vending machine class to access functionality.
        // kept it simple to either choose an item or quit for demonstration purposes.
        // Conducts basic error handling. Should we want to add more functionality, item type selector logic should be added.

        public class App
        {
            private readonly IVendingMachine _machine;

            public App(IVendingMachine vendingMachine)
            {
                _machine = vendingMachine;
            }

            public void Run()
            {
                Console.WriteLine("Welcome to the vending machine.");
                string userInput;

                while (true)
                {
                    Console.WriteLine("Press 1 to purchase a bag of chips or q to quit.");
                    userInput = Console.ReadLine();
                    if (userInput?.ToLower() == "q")
                    {
                        Console.WriteLine("Thanks for shopping with us!");
                        break;
                    }
                    
                    if (int.TryParse(userInput, out int res) )
                    {
                        if (res == 1)
                        {
                            ProcessTransaction(res, userInput);
                        }

                        else
                        {
                            Console.WriteLine("Please select a valid option.");
                        }

                        
                    }
                }
            }
            private void ProcessTransaction(int selection, string userInput)
            {
                if (_machine.SelectItem(selection))
                    {
                        Console.WriteLine("Please enter your cash in whole dollars.");
                        userInput = Console.ReadLine();

                        if (!int.TryParse(userInput, out int cash) || cash < 0)
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        bool correct = _machine.InputCash(cash);
                        if (correct)
                        {
                            _machine.Dispense();
                        }

                    }
                    
            }
        }
    }
}

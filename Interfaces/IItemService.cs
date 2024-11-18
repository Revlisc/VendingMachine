using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IItemService
    {

        bool CheckInventory(int id);
        Item GetItem(int id);
        void ReduceStock(int id);
    }
}

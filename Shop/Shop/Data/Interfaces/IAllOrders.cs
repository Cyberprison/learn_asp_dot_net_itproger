using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
    }
}

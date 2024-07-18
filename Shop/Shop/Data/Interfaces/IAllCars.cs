using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IAllCars
    {
        //все машины
        IEnumerable<Car> Cars { get; }

        //избранные машины
        IEnumerable<Car> getFavCars { get; set; }

        //машина по айди
        Car getObjectCar(int carId);
        
    }
}

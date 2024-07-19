using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shop.Data.Models;
using Shop.Data.Interfaces;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    //добавить ещё машины

                    //скачать картинки и прописать путь

                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "",
                        longDesc = "",
                        img = "", 
                        price = 2500000,
                        isFavourite = true,
                        available = true,
                        //categoryID = ,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        name = "Lada",
                        shortDesc = "",
                        longDesc = "",
                        img = "",
                        price = 150000,
                        isFavourite = false,
                        available = true,
                        //categoryID = ,
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}

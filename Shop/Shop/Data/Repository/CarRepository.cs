using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Data.Entity;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;
        
        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars
        {
            get
            {
                return appDBContent.Car.Include(c => c.Category);
            }
        }

        public IEnumerable<Car> getFavCars
        {
            get {
                return appDBContent.Car.Where(p => p.isFavourite).Include(c => c.Category);
            }
        }

        public Car getObjectCar(int carId)
        {
            return appDBContent.Car.FirstOrDefault(p => p.id == carId);
        }
    }
}

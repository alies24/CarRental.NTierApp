using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarAdd();

        }

        private static void CarAdd()
        {
            Car car = new Car();
            car.ColorId = 1;
            car.BrandId = 1;
            car.ModelYear = 2000;
            car.DailyPrice = 150;
            car.Description = "Deneme";

            ICarService carService = new CarManager(new EfCarDal());
            carService.Add(car);
        }
    }
}

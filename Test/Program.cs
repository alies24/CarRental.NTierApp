using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFrameworkCore;
using Entities.Concrete;
using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarAdd();
            //BrandAdd();
            //CarDelete();
            GetBrands();            
            //GetCustomer(1);
        }

        public static void CarAdd()
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
        private static void BrandAdd()
        {
            Brand brand = new Brand();
   
            IBrandService brandService = new BrandManager(new EfBrandDal());
            brandService.Delete(brand);
          
        }
        private static void CarDelete()
        {
            Car car = new Car();
            car.CarId = 1;
            car.ColorId = 1;
            car.BrandId = 1;
            car.ModelYear = 2000;
            car.DailyPrice = 150;
            car.Description = "Deneme";
            ICarService carService = new CarManager(new EfCarDal());
            carService.Delete(car);
        }
        private static void GetBrands()
        {
            IBrandService brandService = new BrandManager(new EfBrandDal());
            foreach (var item in brandService.GetAllBrands().Data)
            {
                Console.WriteLine(item.Name);

            }
            
        }
        private static void GetCustomer(int id)
        {
            ICustomerService customerService = new CustomerManager(new EfCustomerDal());
            var result = customerService.GetCustomer(id);
            Console.WriteLine(result.Data.CompanyName);
            
        }
    }
}

using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);                    
            }
            else
            {
                throw new Exception("Kurallara uygun değil.");
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            var getAll = _carDal.GetAll();
            return getAll;

        }

        public Car GetCar(int carId)
        {
            var getCar = _carDal.Get(c => c.CarId == carId);
            return getCar;
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            var getCarsByBrandId = _carDal.GetAll(c => c.BrandId == brandId);
            return getCarsByBrandId;
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            var getCarsByColorId = _carDal.GetAll(c => c.ColorId == colorId);
            return getCarsByColorId;
        }

        public List<Car> GetCarsByDailyPrice(decimal min, decimal max)
        {
            var getCarsByDailyPrice = _carDal.GetAll(c=>c.DailyPrice >= min && c.DailyPrice <=max );
            return getCarsByDailyPrice;
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

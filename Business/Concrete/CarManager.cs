using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
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
        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
              return new SuccessResult();

            }
            else
            {
                return new ErrorResult();
            }

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
            
        }

        public IDataResult<List<Car>> GetAll()
        {
           var getAll = new SuccessDataResult<List<Car>>(_carDal.GetAll());
            return getAll;

        }

        public IDataResult<Car> GetCar(int carId)
        {
            var getCar = new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
            return getCar;
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            var getCarDetails = new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
            return getCarDetails;
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var getCarsByBrandId = new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
            return getCarsByBrandId;
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var getCarsByColorId = new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
            return getCarsByColorId;
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            var getCarsByDailyPrice = new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
            return getCarsByDailyPrice;
        }

        public IResult Update(Car car)
        {
             _carDal.Update(car);
            return new SuccessResult();
        }
    }
}

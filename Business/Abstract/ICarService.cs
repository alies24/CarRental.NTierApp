using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetCar(int carId);
        IDataResult<List<Car>> GetAllCars();
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailsDto>> GetCarDetails();

    }
}

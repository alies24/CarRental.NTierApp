using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IResult Add(IFormFile file, CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);
        IResult Delete(CarImages carImage);
        IDataResult<List<CarImages>> GetCarListByCarId(int carId);
    }
}

using Business.Abstract;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;
        public CarImagesManager(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            carImages.ImagePath = _fileHelper.Upload(file, "wwwroot\\Uploads\\Images\\");
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult();
        }

        public IResult Delete(CarImages carImages)
        {
            _fileHelper.Delete("wwwroot\\Uploads\\Images\\" + carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult();
        }
        public IResult Update(IFormFile file, CarImages carImages)
        {
            carImages.ImagePath = _fileHelper.Update(file, "wwwroot\\Uploads\\Images\\" + carImages.ImagePath, "wwwroot\\Uploads\\Images\\");
            _carImagesDal.Update(carImages);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImages> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c => c.ImageId == imageId));
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {

            List<CarImages> carImages = new List<CarImages>();
            carImages.Add(new CarImages { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImages>>(carImages);
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}

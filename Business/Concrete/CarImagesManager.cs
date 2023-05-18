using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers.FileHelper;
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
            private ICarImagesDal _carImageDal;
            public CarImagesManager(ICarImagesDal carImageDal)
            {
                _carImageDal = carImageDal;
            }

         
            public IResult Add(IFormFile file, CarImages carImage)
            {
                var imageLimit = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
                if (imageLimit > 5)
                {
                    return new ErrorResult();
                }
                var carImageResult = FileHelperManager.Upload(file);
                if (!carImageResult.Success)
                {
                    return new ErrorResult(carImageResult.Message);
                }
                carImage.ImagePath = carImageResult.Message;
                carImage.Date= DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult();
            }



            public IResult Delete(CarImages carImage)
            {
                var image = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
                if (image != null)
                {
                    FileHelperManager.Delete(image.ImagePath);
                    _carImageDal.Delete(carImage);
                    return new SuccessResult();
                }
                return new ErrorResult();
            }

            public IDataResult<List<CarImages>> GetAll()
            {
                return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
            }

            public IDataResult<CarImages> GetById(int carImageId)
            {
                return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.CarId == carImageId));

            }

            public IDataResult<List<CarImages>> GetCarListByCarId(int carId)
            {
                IResult result = BusinessRules.Run(CarImageCheck(carId));
                if (result != null)
                {
                    return new ErrorDataResult<List<CarImages>>(result.Message);
                }
                return new SuccessDataResult<List<CarImages>>(CarImageCheck(carId).Data);
            }

           
            public IResult Update(IFormFile file, CarImages carImage)
            {
                var image = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
                if (image == null)
                {
                return new ErrorResult();
                }
                var updated = FileHelperManager.Update(file, image.ImagePath);
                if (!updated.Success)
                {
                    return new ErrorResult(updated.Message);
                }
                carImage.ImagePath = updated.Message;
                _carImageDal.Update(carImage);
                return new SuccessResult();
            }

         
            private IDataResult<List<CarImages>> CarImageCheck(int carId)
            {
                try
                {
                    string path = @"\images\logo.jpg";
                    var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                    if (!result)
                    {
                        List<CarImages> carimage = new List<CarImages>();
                        carimage.Add(new CarImages { CarId = carId, ImagePath = path, Date = DateTime.Now });
                        return new SuccessDataResult<List<CarImages>>(carimage);
                    }
                }
                catch (Exception exception)
                {

                    return new ErrorDataResult<List<CarImages>>(exception.Message);
                }

                return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
            }

        }
    }

﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAllCars()
        {
            var getAllCars = _carService.GetAllCars();
            if (getAllCars.Success == true)
            {
                return Ok(getAllCars);
            }
            else
            {
                return BadRequest(getAllCars.Message);
            }
        }
        [HttpGet("get")]
        public IActionResult GetCar(int carId)
        {
            var getById = _carService.GetCar(carId);
            if (getById.Success == true)
            {
                return Ok(getById);
            }
            else
            {
                return BadRequest(getById.Message);
            }
        }
        [HttpGet("getByColor")]
        public IActionResult GetByColorId(int colorId)
        {
            var getByColorId = _carService.GetCarsByColorId(colorId);
            if (getByColorId.Success == true)
            {
                return Ok(getByColorId);
            }
            else
            {
                return BadRequest(getByColorId.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var addCar = _carService.Add(car);
            if (addCar.Success == true)
            {
                return Ok(addCar);
            }
            else
            {
                return BadRequest(addCar.Message);
            }
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var deleteCar = _carService.Delete(car);
            if (deleteCar.Success == true)
            {
                return Ok(deleteCar);
            }
            else
            {
                return BadRequest(deleteCar.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var updateCar = _carService.Update(car);
            if (updateCar.Success == true)
            {
                return Ok(updateCar);
            }
            else
            {
                return BadRequest(updateCar.Message);
            }
        }

        [HttpGet("getByBrand")]
        public IActionResult GetByBrandId(int brandId)
        {
            var getByBrandId = _carService.GetCarsByBrandId(brandId);
            if (getByBrandId.Success == true)
            {
                return Ok(getByBrandId);
            }
            else
            {
                return BadRequest(getByBrandId.Message);
            }
        }
        [HttpGet("getByDailyPrice")]
        public IActionResult GetByDailyPrice(decimal min, decimal max)
        {
            var getByDailyPrice = _carService.GetCarsByDailyPrice(min, max);
            if (getByDailyPrice.Success == true)
            {
                return Ok(getByDailyPrice);
            }
            else
            {
                return BadRequest(getByDailyPrice.Message);
            }
        }

        [HttpGet("getCarDetails")]
        public IActionResult GetCarDetails()
        {
            var getCarsDto = _carService.GetCarDetails();
            if (getCarsDto.Success == true)
            {
                return Ok(getCarsDto);
            }
            else
            {
                return BadRequest(getCarsDto.Message);
            }
        }
  
    }
}

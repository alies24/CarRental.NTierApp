using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;
        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }
        [HttpPost("addImage")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImages carImage)
        {
            var result = _carImagesService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("deleteImage")]
        public IActionResult Delete(CarImages carImage)
        {
            var carDeleteImage = _carImagesService.GetByImageId(carImage.ImageId).Data;
            var result = _carImagesService.Delete(carDeleteImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImages carImages)
        {
            var result = _carImagesService.Update(file, carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllImages")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByCarId")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImagesService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet("getByImageId")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = _carImagesService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

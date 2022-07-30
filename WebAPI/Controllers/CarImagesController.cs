using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
       private ICarImagesService _carImageService;
        public CarImagesController(ICarImagesService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("addImage")]
        public IActionResult Add([FromForm] IFormFile image, [FromForm] CarImages img)
        {
            var result = _carImageService.Add(image, img);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deleteImage")]
        public IActionResult Delete(CarImages img)
        {
            var result = _carImageService.Delete(img);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateImage")]
        public IActionResult Update([FromForm] IFormFile image, [FromForm] CarImages img)
        {
            var result = _carImageService.Update(image, img);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getCarListByCarId")]
        public IActionResult GetCarListByCarId(int carId)
        {
            var result = _carImageService.GetCarListByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}


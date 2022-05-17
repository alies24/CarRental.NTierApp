using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getColor")]
        public IActionResult GetColor(int colorId)
        {
            var getColor = _colorService.GetColor(colorId);
            if (getColor.Success == true)
            {
                return Ok(getColor);

            }
            else
            {
                return BadRequest(getColor.Message);
            }
        }

        [HttpGet("getAllColors")]
        public IActionResult GetAllColors()
        {
            var getAllColors = _colorService.GetAllColors();
            if (getAllColors.Success == true)
            {
                return Ok(getAllColors);

            }
            else
            {
                return BadRequest(getAllColors.Message);
            }
        }
        [HttpPost("addColor")]
        public IActionResult Add(Color color)
        {
            var addColor = _colorService.Add(color);
            if (addColor.Success == true)
            {
                return Ok(addColor);

            }
            else
            {
                return BadRequest(addColor.Message);
            }
        }
        [HttpDelete("deleteColor")]
        public IActionResult Delete(Color color)
        {
            var deleteColor = _colorService.Delete(color);
            if (deleteColor.Success == true)
            {
                return Ok(deleteColor);

            }
            else
            {
                return BadRequest(deleteColor.Message);
            }
        }
        [HttpPut("updateColor")]
        public IActionResult Update(Color color)
        {
            var updateColor = _colorService.Update(color);
            if (updateColor.Success == true)
            {
                return Ok(updateColor);

            }
            else
            {
                return BadRequest(updateColor.Message);
            }
        }
    }
}

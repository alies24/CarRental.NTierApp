using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getAllBrands")]
        public IActionResult GetAllBrands()
        {
            var getAllBrands = _brandService.GetAllBrands();
            if (getAllBrands.Success == true)
            {
                return Ok(getAllBrands);
            }
            else
            {
                return BadRequest(getAllBrands.Message);
            }
        }
        [HttpGet("getBrand")]
        public IActionResult GetBrand(int brandId)
        {
            var getBrand = _brandService.GetBrand(brandId);
            if (getBrand.Success == true)
            {
                return Ok(getBrand);
            }
            else
            {
                return BadRequest(getBrand.Message);
            }
        }
        [HttpPost("addBrand")]
        public IActionResult Add(Brand brand)
        {
            var addBrand = _brandService.Add(brand);
            if (addBrand.Success == true)
            {
                return Ok(addBrand);
            }
            else
            {
                return BadRequest(addBrand.Message);
            }
        }
        [HttpPut("updateBrand")]
        public IActionResult Update(Brand brand)
        {
            var updateBrand = _brandService.Update(brand);
            if (updateBrand.Success==true)
            {
                return Ok(brand);
            }
            else
            {
                return BadRequest(updateBrand.Message);
            }
        }
         [HttpDelete("deleteBrand")]
         public IActionResult Delete(Brand brand)
        {
            var deleteBrand = _brandService.Delete(brand);
            if (deleteBrand.Success == true)
            {
                return Ok(deleteBrand);

            }
            else
            {
                return BadRequest(deleteBrand.Message);
            }
        }

        
    }
}

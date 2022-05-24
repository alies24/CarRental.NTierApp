using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getRental")]
        public IActionResult GetRental(int rentalId)
        {
            var getRental = _rentalService.GetRental(rentalId);
            if (getRental.Success == true)
            {
                return Ok(getRental);

            }
            else
            {
                return BadRequest(getRental.Message);
            }
        }

        [HttpGet("getAllRentals")]
        public IActionResult GetAllRentals()
        {
            var getAllRentals = _rentalService.GetAllRentals();
            if (getAllRentals.Success == true)
            {
                return Ok(getAllRentals);

            }
            else
            {
                return BadRequest(getAllRentals.Message);
            }
        }
        [HttpPost("addRental")]
        public IActionResult Add(Rental rental)
        {
            var addRental = _rentalService.Add(rental);
            if (addRental.Success == true)
            {
                return Ok(addRental);

            }
            else
            {
                return BadRequest(addRental.Message);
            }
        }
        [HttpDelete("deleteRental")]
        public IActionResult Delete(Rental rental)
        {
            var deleteRental = _rentalService.Delete(rental);
            if (deleteRental.Success == true)
            {
                return Ok(deleteRental);

            }
            else
            {
                return BadRequest(deleteRental.Message);
            }
        }
        [HttpPut("updateRental")]
        public IActionResult Update(Rental rental)
        {
            var updateRental = _rentalService.Update(rental);
            if (updateRental.Success == true)
            {
                return Ok(updateRental);

            }
            else
            {
                return BadRequest(updateRental.Message);
            }
        }
    }
}

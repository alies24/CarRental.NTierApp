using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var addCustomer = _customerService.Add(customer);
            if (addCustomer.Success == true)
            {
                return Ok(addCustomer);
            }
            else
            {
                return BadRequest(addCustomer.Message);
            }
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer)
        {
            var deleteCustomer = _customerService.Delete(customer);
            if (deleteCustomer.Success == true)
            {
                return Ok(deleteCustomer);
            }
            else
            {
                return BadRequest(deleteCustomer.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(Customer customer)
        {
            var updateCustomer = _customerService.Update(customer);
            if (updateCustomer.Success == true)
            {
                return Ok(updateCustomer);
            }
            else
            {
                return BadRequest(updateCustomer.Message);
            }
        }
        [HttpGet("get")]
        public IActionResult GetCustomer(int customerId)
        {
            var getCustomer = _customerService.GetCustomer(customerId);
            if (getCustomer.Success == true)
            {
                return Ok(getCustomer);
            }
            else
            {
                return BadRequest(getCustomer.Message);
            }
        }
        [HttpGet("getAll")]
        public IActionResult GetAllCustomers()
        {
            var getAllCustomers= _customerService.GetAllCustomers();
            if (getAllCustomers.Success == true)
            {
                return Ok(getAllCustomers);
            }
            else
            {
                return BadRequest(getAllCustomers.Message);
            }
        }
        [HttpGet("getCustomerDetails")]
        public IActionResult GetCustomerDetails()
        {
            var getCustomerDetails = _customerService.GetCustomerDetails();
            if (getCustomerDetails.Success == true)
            {
                return Ok(getCustomerDetails);
            }
            else
            {
                return BadRequest(getCustomerDetails.Message);
            }
        }

    }
}

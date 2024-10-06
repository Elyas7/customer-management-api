using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Models;
using System.Text.RegularExpressions;
using CustomerAPI.Services;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult AddCustomer ([FromBody] Customer customer)
        {
            try
            {
                _customerService.AddCustomer(customer);
                return Ok("Customer added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

    }
}

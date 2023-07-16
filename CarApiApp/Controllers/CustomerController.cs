using CarApiApp.Models;
using CarApiApp.Services;
using CarApiApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CarApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository= customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        { 
            var customers = await _customerRepository.GetAllAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Add(CustomerForCreate customer)
        {
            var newCustomer = new Customer()
            {
                Name = customer.Name,
                Address = customer.Address,
                Age = customer.Age,
            };
            await _customerRepository.AddAsync(newCustomer);
            return Ok(customer);   
        }
       
    }
}

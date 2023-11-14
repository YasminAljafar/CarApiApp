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
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return Ok(customer);
        }
        /// <summary>
        /// end point for update
        /// </summary>
        /// <param name="cutomer"></param>
        /// <param name="id"></param>
        /// <returns>updated customer</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Update(CustomerForCreate customer, int id)
        {
            var existingcustomer = await _customerRepository.GetByIdAsync(id);
            if (existingcustomer == null)
            {
                return NotFound();
            }
            existingcustomer.Name = customer.Name;
            existingcustomer.Address = customer.Address;
            existingcustomer.Age = customer.Age;
 
            await _customerRepository.UpdateAsync(existingcustomer);
            return Ok(existingcustomer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var customer = await _customerRepository.DeleteAsync(id);
            return Ok(customer + "has deletd");
        }
    }
}

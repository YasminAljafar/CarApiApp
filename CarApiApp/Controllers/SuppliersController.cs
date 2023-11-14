using CarApiApp.Models;
using CarApiApp.Services;
using CarApiApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersController(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> GetAll()
        {
            var suppliers = await _suppliersRepository.GetAllAsync();
            return Ok(suppliers);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> Add(SupplierForCreate supplier)
        {
            var newSupplier = new Supplier()
            {
                Name = supplier.Name,
                Address = supplier.Address,   
            };
            await _suppliersRepository.AddAsync(newSupplier);
            return Ok(supplier);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetById(int id)
        {
            var supplier = await _suppliersRepository.GetByIdAsync(id);
            return Ok(supplier);
        }
        /// <summary>
        /// end point for update
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="id"></param>
        /// <returns>updated supplier</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Supplier>> Update(SupplierForCreate supplier, int id)
        {
            var existingSupplier = await _suppliersRepository.GetByIdAsync(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }
            existingSupplier.Name = supplier.Name;
            existingSupplier.Address = supplier.Address;

            await _suppliersRepository.UpdateAsync(existingSupplier);
            return Ok(existingSupplier);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Supplier>> Delete(int id)
        {
            var supplier = await _suppliersRepository.DeleteAsync(id);
            return Ok(supplier +"has deleted");
        }

    }
}

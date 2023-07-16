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

    }
}

using CarApiApp.Models;
using CarApiApp.Services;
using CarApiApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetAll()
        {
            var sales = await _saleRepository.GetAllAsync();
            return Ok(sales);
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> Add(SaleForCreate sale)
        {
            var newSale = new Sale()
            {
                total = sale.total,
                CarId = sale.CarId,
                CustomerId = sale.CustomerId,
            };
            await _saleRepository.AddAsync(newSale);
            return Ok(sale);
        }

    }
}

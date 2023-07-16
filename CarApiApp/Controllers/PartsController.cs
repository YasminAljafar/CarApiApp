using CarApiApp.Models;
using CarApiApp.Services;
using CarApiApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IPartRepository _partRepository;

        public PartsController(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Part>>> GetAll()
        {
            var parts = await _partRepository.GetAllAsync();
            return Ok(parts);
        }

        [HttpPost]
        public async Task<ActionResult<Part>> Add(PartForCreate part)
        {
            var newPart = new Part()
            {
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity,
                SupplierId = part.SupplierId,
            };
            await _partRepository.AddAsync(newPart);
            return Ok(part);
        }

    }
}

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

        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetById(int id)
        {
            if (id > 0)
            {
                var part = await _partRepository.GetByIdAsync(id);
                return Ok(part);
            }
            else return NotFound();
        }
        /// <summary>
        /// end point for update
        /// </summary>
        /// <param name="cutomer"></param>
        /// <param name="id"></param>
        /// <returns>updated customer</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Part>> Update(PartForCreate part, int id)
        {
            var existingpart = await _partRepository.GetByIdAsync(id);
            if (existingpart == null)
            {
                return NotFound();
            }
            existingpart.Name = part.Name;
            existingpart.Price = part.Price;
            existingpart.Quantity = part.Quantity;
            existingpart.SupplierId=part.SupplierId;
          
            await _partRepository.UpdateAsync(existingpart);
            return Ok(existingpart);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Part>> Delete(int id)
        {
            var part = await _partRepository.DeleteAsync(id);
            return Ok(part +"has deletd");
        }
    }
}

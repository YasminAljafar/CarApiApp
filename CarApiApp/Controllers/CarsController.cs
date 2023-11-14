using CarApiApp.Models;
using CarApiApp.Services;
using CarApiApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _carRepository.GetAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Add(CarForCreate car)
        {
            var newCar = new Car()
            {
                Model = car.Model,
                Year = car.Year,
                Km = car.Km,
                Gear = car.Gear,
            };
            await _carRepository.AddAsync(newCar);
            return Ok(car);
        }

        /// <summary>
        /// end point for update
        /// </summary>
        /// <param name="car"></param>
        /// <param name="id"></param>
        /// <returns>updated car</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> Update(CarForCreate car, int id)
        {
            var existingcar= await _carRepository.GetByIdAsync(id);
            if (existingcar == null)
            {
                return NotFound();
            }
            existingcar.Year = car.Year;
            existingcar.Km = car.Km;
            existingcar.Gear = car.Gear;
            existingcar.Model = car.Model;
            await _carRepository.UpdateAsync(existingcar);
            return Ok(existingcar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            var car = await _carRepository.DeleteAsync(id);
            return Ok( "has deletd");
        }
    }
}

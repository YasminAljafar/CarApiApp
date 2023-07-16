using CarApiApp.Data;
using CarApiApp.Models;
using CarApiApp.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CarApiApp.Services
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        //new public async Task<Car> UpdateAsync(Car car, int id)
        //{
        //    var existCar = await _context.Cars.SingleOrDefaultAsync(c => c.Id == id);
        //    if (existCar == null)
        //    {
        //        return BadRequest("not found");
        //    }
        //    //existCar.Id = id;
        //    //existCar.Model = car.Model;
        //    //existCar.Year = car.Year;
        //    //existCar.Km = car.Km;
        //    //existCar.Gear = car.Gear;

        //    _context.Cars.Update(existCar);
        //    await _context.SaveChangesAsync();
        //    return existCar;
        //}

        private Car BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}

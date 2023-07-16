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
       new public async Task<Car?> GetByIdAsync(int id)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(c=>c.Id==id);
            return car;
        }
        
    }
}

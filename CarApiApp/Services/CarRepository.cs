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

        new public async Task<Car> DeleteAsync(int id)
        {
            var x = await _context.Set<Car>().SingleOrDefaultAsync(s => s.Id == id);
            _context.Remove(x);
            await _context.SaveChangesAsync();
            return x;
        }

    }
}

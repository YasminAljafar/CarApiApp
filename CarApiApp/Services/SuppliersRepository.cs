using CarApiApp.Data;
using CarApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApiApp.Services
{
    public class SuppliersRepository : GenericRepository<Supplier>, ISuppliersRepository
    {
        private readonly ApplicationDbContext _context;
        public SuppliersRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       new public async Task<Supplier?> GetByIdAsync(int id)
        {
            var supplier = await _context.Set<Supplier>().SingleOrDefaultAsync(s=>s.Id==id);
            return supplier;
        }

      new public async Task<Supplier> DeleteAsync(int id)
        {
            var x = await _context.Set<Supplier>().SingleOrDefaultAsync(s=>s.Id==id);
            _context.Remove(x);
            await _context.SaveChangesAsync();
            return x;
        }
    }
}

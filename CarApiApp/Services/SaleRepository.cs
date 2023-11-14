using CarApiApp.Data;
using CarApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApiApp.Services
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        new public async Task<Sale?> GetByIdAsync(int id)
        {
            var sale = await _context.Set<Sale>().SingleOrDefaultAsync(s=>s.Id==id);
            return sale;
        }

        new public async Task<Sale> DeleteAsync(int id)
        {
            var x = await _context.Set<Sale>().SingleOrDefaultAsync(s => s.Id == id);
            _context.Remove(x);
            await _context.SaveChangesAsync();
            return x;
        }
    }
}

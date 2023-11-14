using CarApiApp.Data;
using CarApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApiApp.Services
{
    public class PartRepository : GenericRepository<Part>, IPartRepository
    {
        private readonly ApplicationDbContext _context;
        public PartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        new public async Task<Part?> GetByIdAsync(int id)
        {
            var part = await _context.Parts.SingleOrDefaultAsync(x => x.Id == id);
            return part;
        }

        new public async Task<Part> DeleteAsync(int id)
        {
            var x = await _context.Set<Part>().SingleOrDefaultAsync(s => s.Id == id);
            _context.Remove(x);
            await _context.SaveChangesAsync();
            return x;
        }
    }
}

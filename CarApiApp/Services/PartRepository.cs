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
    }
}

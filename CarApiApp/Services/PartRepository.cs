using CarApiApp.Data;
using CarApiApp.Models;

namespace CarApiApp.Services
{
    public class PartRepository : GenericRepository<Part>, IPartRepository
    {
        public PartRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

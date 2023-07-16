using CarApiApp.Data;
using CarApiApp.Models;

namespace CarApiApp.Services
{
    public class SuppliersRepository : GenericRepository<Supplier>, ISuppliersRepository
    {
        public SuppliersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

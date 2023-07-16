using CarApiApp.Data;
using CarApiApp.Models;

namespace CarApiApp.Services
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

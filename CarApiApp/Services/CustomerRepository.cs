using CarApiApp.Data;
using CarApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApiApp.Services
{
    public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository 
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
           _context=context;
        }
        new public async Task<Customer?> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        new public async Task<Customer> DeleteAsync(int id)
        {
            var x = await _context.Set<Customer>().SingleOrDefaultAsync(s => s.Id == id);
            _context.Remove(x);
            await _context.SaveChangesAsync();
            return x;
        }
    }
}

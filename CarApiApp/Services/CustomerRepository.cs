using CarApiApp.Data;
using CarApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApiApp.Services
{
    public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository 
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}

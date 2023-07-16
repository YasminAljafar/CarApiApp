﻿using CarApiApp.Data;
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
    }
}

using CarApiApp.Data;
using CarApiApp.ViewModels;
using CarApiApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CarApiApp.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var car = await _context.Set<TEntity>().FirstOrDefaultAsync();
            return car;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if(entity == null)
            {
                return false;
            }
           
             _context.Set<TEntity>().Update(entity);
             await _context.SaveChangesAsync();
            return true;
        }
    }
}

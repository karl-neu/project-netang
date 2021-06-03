using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly AppDbContext _dbContext;

        public AnimalRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Animal> GetByIdAsync(int id)
        {
            return _dbContext.Animals.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<Animal>> ListAsync()
        {
            return _dbContext.Animals.ToListAsync();
        }

        public async Task<Animal> AddAsync(Animal entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task UpdateAsync(Animal entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Animal entity)
        {
            _dbContext.Animals.Remove(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AnimalRequestRepository : IRepository<AnimalRequest>
    {
        private readonly AppDbContext _dbContext;

        public AnimalRequestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<AnimalRequest> GetByIdAsync(int id)
        {
            return _dbContext.AnimalRequests.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<AnimalRequest>> ListAsync()
        {
            return _dbContext.AnimalRequests.ToListAsync();
        }

        public async Task<AnimalRequest> AddAsync(AnimalRequest entity)
        {
            await _dbContext.AnimalRequests.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task UpdateAsync(AnimalRequest entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(AnimalRequest entity)
        {
            _dbContext.AnimalRequests.Remove(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
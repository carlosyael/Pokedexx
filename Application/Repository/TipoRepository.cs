using Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class TipoRepository
    {
        private readonly ApplicationContext _dbContext;

        public TipoRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Tipo tipo)
        {
            await _dbContext.Tipos.AddAsync(tipo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Tipo tipo)
        {
            _dbContext.Entry(tipo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Tipo tipo)
        {
            _dbContext.Set<Tipo>().Remove(tipo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Tipo>> GetAllAsync()
        {
            return await _dbContext.Set<Tipo>().ToListAsync();

        }
        public async Task<Tipo> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Tipo>().FindAsync(id);

        }
    }
}

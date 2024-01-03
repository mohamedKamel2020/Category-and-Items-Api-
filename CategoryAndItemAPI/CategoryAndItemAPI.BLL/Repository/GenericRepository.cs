using CategoryAndItemAPI.BLL.Interfaces;
using CategoryAndItemAPI.DAL.Context;
using CategoryAndItemAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryAndItemAPI.BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CategoryItemApiContext _dbContex;
        public GenericRepository(CategoryItemApiContext dbContext) {
            _dbContex=dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
             => await _dbContex.Set<T>().FindAsync(id);
        // => await _context.Set<T>().Where(item => item.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Item))
            {
                return (IEnumerable<T>) await _dbContex.Set<Item>().Include(I => I.Category).ToListAsync();
            }
            return (IEnumerable<T>)await _dbContex.Set<T>().ToListAsync();
        }
    }
}

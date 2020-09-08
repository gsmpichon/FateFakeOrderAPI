using FateFakeOrder.Data;
using FateFakeOrder.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly FFOContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseService(FFOContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }


        public async Task Add(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(includeProperties != null )
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if(orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByID(int id)
        {
            TEntity entityFound = await _dbSet.FindAsync(id);
            if (entityFound == null)
                return null;
            return entityFound;
        }

        public async Task Remove(int id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete == null)
                return;
            _dbSet.Remove(entityToDelete);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity obj)
        {
             _dbSet.Update(obj);
        }
    }
}

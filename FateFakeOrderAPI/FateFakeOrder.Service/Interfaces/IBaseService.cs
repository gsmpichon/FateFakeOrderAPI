using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Interfaces
{
    public interface IBaseService <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");

        Task Remove(int id);

        Task Add(TEntity obj);

        void Update(TEntity obj);

        Task Save();

        Task<TEntity> GetByID(int id);
    }
}

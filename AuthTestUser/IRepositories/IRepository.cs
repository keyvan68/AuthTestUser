using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTestUser.IRepositories
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class
        where TKey : struct
    {
        void Add(TEntity entity);
        void AddRange(IList<TEntity> entites);
        TEntity Find(TKey id);
        IQueryable<TEntity> GetAllWithOutCond();

        //Task<IQueryable<TEntity>> GetAllWithOutCond();
        void Remove(TEntity entity);

        void Remove(TKey id);

        void Update(TEntity entity);


    }
}

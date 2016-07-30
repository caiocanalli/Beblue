using System.Collections.Generic;

namespace Beblue.Domain.Interfaces.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int skip, int take);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}

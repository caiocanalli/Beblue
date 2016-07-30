using System.Collections.Generic;

namespace Beblue.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int skip, int take);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}

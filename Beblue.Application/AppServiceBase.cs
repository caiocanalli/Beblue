using Beblue.Application.Interfaces;
using Beblue.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace Beblue.Application
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }

        public void Add(TEntity entity)
        {
            _service.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public IEnumerable<TEntity> GetAll(int skip, int take)
        {
            return _service.GetAll(skip, take);
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _service.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _service.Update(entity);
        }
    }
}

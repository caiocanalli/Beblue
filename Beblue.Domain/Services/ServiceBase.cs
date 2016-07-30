using Beblue.Domain.Interfaces.Repository;
using Beblue.Domain.Interfaces.Service;
using System.Collections.Generic;
using System;

namespace Beblue.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetAll(int skip, int take)
        {
            return _repository.GetAll(skip, take);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}

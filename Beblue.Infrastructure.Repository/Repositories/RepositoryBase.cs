using Beblue.Domain.Interfaces.Repository;
using Beblue.Infrastructure.Repository.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Beblue.Infrastructure.Repository.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public BeblueDbContext db = new BeblueDbContext();

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(int skip, int take)
        {
            return db.Set<TEntity>().Skip(skip).Take(take).ToList();
        }

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

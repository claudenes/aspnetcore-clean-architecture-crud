using Colorado.Domain.Exceptions;
using Colorado.Domain.Interfaces;
using Colorado.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Colorado.Infra.Data.Repositories
{
    public class ResourceRepository<TEntity> : IResourceRepository<TEntity> where TEntity : class
    {
        protected readonly string NotFoundMsg = "Registro(s) não encontrado(s)";
        protected ApplicationDbContext _db;

        public ResourceRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public TEntity Create(TEntity o)
        {
            using (var t = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Set<TEntity>().Add(o);
                    _db.SaveChanges();
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
            return o;
        }

        public TEntity Delete(int id)
        {
            TEntity o = ReadById(id);
            if (o != null)
            {
                _db.Set<TEntity>().Remove(o);
                _db.SaveChanges();
            }
            else
            {
                BusinessException ex = new(NotFoundMsg);
                throw ex;
            }
            return o;
        }

        public TEntity Delete(TEntity o)
        {
            if (o != null)
            {
                _db.Set<TEntity>().Remove(o);
                _db.SaveChanges();
            }
            else
            {
                BusinessException ex = new(NotFoundMsg);
                throw ex;
            }
            return o;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _db.Set<TEntity>().Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public string GetConnectionString()
        {
            return _db.Database.GetConnectionString();
        }

        public IList<TEntity> ReadAll()
        {
            return _db.Set<TEntity>().ToList<TEntity>();
        }

        public TEntity ReadById(int id)
        {
            TEntity o = _db.Set<TEntity>().Find(id);
            if (o != null)
            {
                return o;
            }
            else
            {
                BusinessException ex = new(NotFoundMsg);
                throw ex;
            }
        }

        public TEntity Update(TEntity o)
        {
            using (var t = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _db.SaveChanges();
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
            return o;
        }
    }
}

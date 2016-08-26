using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Common.Entities.Base;
using DAL.Common.Repositories.Base;

namespace DAL.EF.Repositories.Base
{
    /// <summary>
    /// An implementation of <see cref="IRepository{T}"/>
    /// This repository only a adapter to EfContext which gives you 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EFBaseRepository<T> : IChildrenRepository<T>, IRepository<T> where T : class, IBaseEntity
    {
        private readonly DbContext _dbContext;

        protected EFBaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected virtual DbSet<T> DbSet
        {
            get { return _dbContext.Set<T>(); }
        }

        public void Create(T t)
        {
            DbSet.Add(t);
            _dbContext.SaveChanges();
        }

        public void Remove(T t)
        {
            DbSet.Remove(t);
            _dbContext.SaveChanges();
        }

        public void CreateOrUpdate(T t)
        {
            DbSet.AddOrUpdate(t);
            _dbContext.SaveChanges();
        }
        public void Update(T t)
        {
            t.LastModifiedDate = DateTimeOffset.UtcNow;
            var entry = _dbContext.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public Task<T> FindAsync(params object[] keys)
        {
            return DbSet.FindAsync(keys);
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return DbSet.SingleOrDefault(expression);
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return DbSet.SingleOrDefaultAsync(expression);
        }

        public TCh Find<TCh>(Expression<Func<TCh, bool>> expression) where TCh : T
        {
            return DbSet.OfType<TCh>().SingleOrDefault(expression);
        }
    }
}
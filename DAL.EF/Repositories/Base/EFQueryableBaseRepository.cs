using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Common.Entities.Base;
using DAL.Common.Repositories.Base;

namespace DAL.EF.Repositories.Base
{
    public class EFQueryableBaseRepository<T> : EFBaseRepository<T>, IQueryableRepository<T> where T : class, IBaseEntity
    {
        public EFQueryableBaseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null)
        {

            var result = filter == null ?
                DbSet.AsQueryable() :
                DbSet.Where(filter);
            return result;
        }
    }
}
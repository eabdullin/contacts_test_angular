using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Common.Entities.Common;
using DAL.Common.Repositories;
using DAL.EF.Repositories.Base;

namespace DAL.EF.Repositories
{
    public class EFDictionaryRepository : EFBaseRepository<Dictionary>, IDictionaryRepository
    {
        public EFDictionaryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Dictionary> GetAll(string type)
        {
            return DbSet.Where(x => x.Id.StartsWith(type)).ToList();
        }
    }
}
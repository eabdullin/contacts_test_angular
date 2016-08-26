using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Common.Entities;
using DAL.Common.Repositories;
using DAL.EF.Repositories.Base;

namespace DAL.EF.Repositories
{
    public class EFContactRepository : EFBaseRepository<Contact>, IContactRepository
    {
        public EFContactRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Contact> Get(out int totalCount, int? page, int? countperpage, string q, string genderCode, string companyId, string jobTitleId)
        {
            var query = DbSet.AsQueryable();
            if (q != null)
            {
                query =
                    query.Where(
                        x =>
                            x.Phone.Contains(q) || x.FirstName.StartsWith(q) || x.LastName.StartsWith(q) ||
                            x.Email.Contains(q));
            }
            if (genderCode != null)
            {
                query = query.Where(x => x.GenderId == genderCode);
            }
            if (companyId != null)
            {
                query = query.Where(x => x.CompanyId == companyId);
            }
            if (jobTitleId != null)
            {
                query = query.Where(x => x.JobTitleId == jobTitleId);
            }
            totalCount = query.Count();
            if (page.HasValue && countperpage.HasValue)
            {
                query = query.OrderBy(x => x.FirstName).Skip(page.Value*countperpage.Value).Take(countperpage.Value);
            }
            return query.ToList();
        }
    }
}
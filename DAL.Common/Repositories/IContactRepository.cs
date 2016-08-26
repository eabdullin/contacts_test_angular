using System.Collections;
using System.Collections.Generic;
using DAL.Common.Entities;
using DAL.Common.Repositories.Base;

namespace DAL.Common.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        IList<Contact> Get(
            out int totalCount,
            int? page, 
            int? countperpage, 
            string q, 
            string genderCode, 
            string companyId,
            string jobTitleId
            );
    }
}
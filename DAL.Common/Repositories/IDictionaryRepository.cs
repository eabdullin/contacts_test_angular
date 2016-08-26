using System.Collections;
using System.Collections.Generic;
using DAL.Common.Entities.Common;
using DAL.Common.Repositories.Base;

namespace DAL.Common.Repositories
{
    public interface IDictionaryRepository : IRepository<Dictionary>
    {
        IList<Dictionary> GetAll(string type);
    }
}
using System;
using System.Linq.Expressions;

namespace DAL.Common.Repositories.Base
{
    /// <summary>
    /// The main idea of this type of repo is deviding hierarchical entities 
    /// </summary>
    /// <typeparam name="TP"></typeparam>
    public interface IChildrenRepository<TP>
    {
        TCh Find<TCh>(Expression<Func<TCh, bool>> expression) where TCh : TP;
    }
}
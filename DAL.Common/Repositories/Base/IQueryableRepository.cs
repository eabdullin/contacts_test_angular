using System;
using System.Linq;
using System.Linq.Expressions;
using DAL.Common.Entities.Base;

namespace DAL.Common.Repositories.Base
{
    /// <summary>
    /// Use this repository to access your store throw using a Linq expressions. 
    /// That's simple way to build simple queries like a [select top from] and etc.
    /// Generally, I reccomend to create your own Repositories for every Entity implemented from this,
    /// in case you want to do non-trivial queries(e.g. with several joins, etc.).
    /// 
    /// Используйте данный интерфейс для доступа к вашему хранилищу с помощью Linq 
    /// Это довольно простой способ создавать запросы типа [select top from] и т.д.
    /// В целом, я рекомендую создавать собственные репозитории для каждой сущности, если вы хотите создавать сложные запросы
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryableRepository<T> : IRepository<T> where T : IBaseEntity
    {
        IQueryable<T> Query(Expression<Func<T, bool>> filter = null);
    }
}
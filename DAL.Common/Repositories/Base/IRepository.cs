using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Common.Entities.Base;

namespace DAL.Common.Repositories.Base
{
    /// <summary> 
    /// Use a repository to separate the logic that retrieves the data 
    /// and maps it to the entity model from the business logic that acts on the model.
    /// If you need to query  entities please <seealso cref="IQueryableRepository{T}"/> 
    /// that implements from this interface and provide one more method to create queries
    /// Generally, I reccomend to create your own Repositories for every Entity implemented from this,
    ///  which will provide non-trivial queries(e.g. with several joins, etc.).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IBaseEntity
    {
        /// <summary>
        /// Create a new object to store. 
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        void Create(T t);

        /// <summary>
        /// Delete the object from store.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>        
        void Remove(T t);

        /// <summary>
        /// Add an object to store, if store contains an object specified with key, then update  
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        void CreateOrUpdate(T t);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        void Update(T t);

        /// <summary>
        /// Find an object with primary keys
        /// </summary>
        /// <param name="keys">Primary keys. Repository also supports composite primary keys</param>
        /// <returns></returns>
        T Find(params object[] keys);

        /// <summary>
        /// Exactly the same method <see cref="Find(object[])"/>, but also support asynchronous calling
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        Task<T> FindAsync(params object[] keys);

        /// <summary>
        /// Find object by specified expression.
        /// Note: Method works as SingleOrDefault, so that throws an exception if store contains are several object which satisfy a described conditions in expression. 
        /// Note: Some kinds of implementations of this interface may not support particular this method.
        /// </summary>
        /// <param name="expression">expression for searching an object. contains one or more conditions</param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Find object by specified expression.
        /// Note: Method works as SingleOrDefault, so that throws an exception if store contains are several object which satisfy a described conditions in expression.
        /// Note: Some kinds of implementations of this interface may not support particular this method.
        /// </summary>
        /// <param name="expression">expression for searching an object. contains one or more conditions</param>
        /// <returns></returns>
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
    }
}
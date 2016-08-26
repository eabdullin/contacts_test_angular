namespace DAL.Common.Entities.Base
{
    public interface IEntity<TKey> : IBaseEntity
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        TKey Id { get; set; }
    }
}
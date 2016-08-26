using System;

namespace DAL.Common.Entities.Base
{
    public interface IBaseEntity
    {
        /// <summary>
        /// Дата создания записи
        /// </summary>
        DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        DateTimeOffset LastModifiedDate { get; set; }
    }
}
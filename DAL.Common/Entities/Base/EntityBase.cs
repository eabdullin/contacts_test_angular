using System;

namespace DAL.Common.Entities.Base
{
    public abstract class EntityBase<T> : IEntity<T>
    {

        public virtual T Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }


        public DateTimeOffset LastModifiedDate { get; set; }


        //public bool IsHistoric { get { return HistoryDate != null; } }
        //public DateTime? HistoryDate { get; set; }

        public override bool Equals(object obj)
        {
            var entityBase = obj as EntityBase<T>;
            return entityBase != null && Id.Equals(entityBase.Id);
        }
    }
}
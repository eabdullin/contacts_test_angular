using DAL.Common.Entities.Base;

namespace DAL.Common.Entities.Common
{
    public abstract class Dictionary : EntityBase<string>
    {
        /// <summary>
        /// Значение
        /// </summary>
        public virtual string Value { get; set; }
    }
}
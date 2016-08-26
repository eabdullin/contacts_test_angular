using DAL.Common.Entities.Base;

namespace DAL.Common.Entities
{
    public class Contact :EntityBase<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public virtual Gender Gender { get; set; }
        public string GenderId { get; set; }

        public string CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
    }
}
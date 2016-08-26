using BLL;

namespace TestApp.Models
{
    public class ContactShortModel
    {
        public long Id { get; set; }
        public string AvatarUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    public class ContactModel :IContactData
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public string Gender { get; set; }
        public string GenderId { get; set; }

        public string CompanyId { get; set; }
        public string Company { get; set; }

        public string JobTitleId { get; set; }
        public string JobTitle { get; set; }
    }
}
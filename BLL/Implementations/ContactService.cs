using DAL.Common.Entities;
using DAL.Common.Repositories;

namespace BLL.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Result CreateContact(IContactData data)
        {
            //check email
            var contact = _contactRepository.Find(x => x.Email == data.Email);
            if (contact != null)
            {
                return Result.Failed("Email is already in use");
            }

            //check phone 
            contact = _contactRepository.Find(x => x.Phone == data.Phone);
            if (contact != null)
            {
                return Result.Failed("Phone number is already in use");
            }
            contact = new Contact()
            {
                AvatarUrl = data.AvatarUrl,
                Email = data.Email,
                GenderId = data.GenderId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Phone = data.Phone,
                JobTitleId = data.JobTitleId,
                CompanyId = data.CompanyId
            };
            _contactRepository.Create(contact);
            return Result.Success;
        }

        public Result EditContact(long id, IContactData data)
        {
            //check email
            var contact = _contactRepository.Find(x => x.Email == data.Email);
            if (contact.Id != id)
            {
                return Result.Failed("Email is already in use");
            }

            //check phone 
            contact = _contactRepository.Find(x => x.Phone == data.Phone);
            if (contact.Id != id)
            {
                return Result.Failed("Phone number is already in use");
            }
            contact = _contactRepository.Find(id);
            contact.AvatarUrl = data.AvatarUrl;
            contact.Email = data.Email;
            contact.GenderId = data.GenderId;
            contact.FirstName = data.FirstName;
            contact.LastName = data.LastName;
            contact.Phone = data.Phone;
            contact.JobTitleId = data.JobTitleId;
            contact.CompanyId = data.CompanyId;
            _contactRepository.Update(contact);
            return Result.Success;
        }

        public Result DeleteContact(long id)
        {
            var contact = _contactRepository.Find(id);
            _contactRepository.Remove(contact);
            return Result.Success;
        }

        public Result UpdateContact(long contactId, IContactData data)
        {
            var contact = _contactRepository.Find(contactId);
            contact.AvatarUrl = data.AvatarUrl;
            if (contact.Email != data.Email && data.Email != null)
            {
                //check email
                var otherContact = _contactRepository.Find(x => x.Email == data.Email);
                if (otherContact != null)
                {
                    return Result.Failed("Email is already in use");
                }
            }

            if (contact.Phone != data.Phone && data.Phone != null)
            {
                //check email
                var otherContact = _contactRepository.Find(x => x.Phone == data.Phone);
                if (otherContact != null)
                {
                    return Result.Failed("Phone number is already in use");
                }
            }
            contact.Email = data.Email;
            contact.GenderId = data.GenderId;
            contact.FirstName = data.FirstName;
            contact.LastName = data.LastName;
            contact.Phone = data.Phone;
            contact.JobTitleId = data.JobTitleId;
            contact.CompanyId = data.CompanyId;
            _contactRepository.Update(contact);
            return Result.Success;
        }
    }
}
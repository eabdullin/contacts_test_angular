using DAL.Common.Entities;

namespace BLL
{
    public interface IContactData
    {
        string FirstName { get;  }
        string LastName { get;  }
        string Phone { get;  }
        string Email { get;  }
        string AvatarUrl { get;  }
        string CompanyId { get;}
        string GenderId { get; set; }
        string JobTitleId { get; set; }
    }
}
using AutoMapper;
using DAL.Common.Entities;
using TestApp.Models;

namespace TestApp.MapProfiles
{
    public class ContactProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Contact, ContactModel>()
                .ForMember(x => x.Company, x => x.MapFrom(z => z.Company.Value))
                .ForMember(x => x.Gender, x => x.MapFrom(z => z.Gender.Value))
                .ForMember(x => x.JobTitle, x => x.MapFrom(z => z.JobTitle.Value));

            CreateMap<Contact, ContactShortModel>();
        }
    }
}
using AutoMapper;
using DAL.Common.Entities.Common;
using TestApp.Models;

namespace TestApp.MapProfiles
{
    public class DictionaryProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Dictionary, DictionaryModel>();
        }

    }
}
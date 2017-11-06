using App.Client.Models;
using App.Web.Api.Contracts;
using AutoMapper;

namespace App.Client.Mappings
{
    public class DtoMappings : Profile
    {
        public DtoMappings()
        {
            CreateMap<SomeDto, SomeModel>().ReverseMap();
        }
    }
}
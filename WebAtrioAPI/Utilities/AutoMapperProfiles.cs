using AutoMapper;
using WebAtrioAPI.DTOs;
using WebAtrioAPI.Entities;

namespace WebAtrioAPI.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        //Mappage des classes DTOs avec les classe EF
        public AutoMapperProfiles()
        {
            CreateMap<PersonneDTO,Personne>();
        }
    }
}

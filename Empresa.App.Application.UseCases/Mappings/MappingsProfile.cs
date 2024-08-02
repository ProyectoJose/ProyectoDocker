using AutoMapper;
using Empresa.App.Application.Dto;
using Empresa.App.Domain;

namespace Empresa.App.Application.UseCases.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Cita, CitaDTO>().ReverseMap();            
        }
    }
}

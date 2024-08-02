using AutoMapper;
using Empresa.App.Application.Dto;
using Empresa.App.Application.Interface.Persistence.Repositories;
using Empresa.App.Application.Interface.UseCases;
using Empresa.App.Cross.Common;
using Microsoft.Extensions.Configuration;

namespace Empresa.App.Application.UseCases
{
    public class CitaApplication : ICitaApplication
    {
        private readonly ICitaRepository _afiliadoRepository;   

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CitaApplication(ICitaRepository afiliadoRepository, IMapper mapper)
        {
            _afiliadoRepository = afiliadoRepository;
            _mapper = mapper;
        }


        public async Task<List<CitaDTO>> ListarCita()   
        {
            var response = new List<CitaDTO>();
            try
            {
                var userEntity = await _afiliadoRepository.ListarCita();

                response = _mapper.Map<List<CitaDTO>>(userEntity);
                 return response;
            }
            catch (Exception ex)
            {
                throw (new Exception());               
            }
            return response;
        }
    }
}

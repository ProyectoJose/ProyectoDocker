using Empresa.App.Application.Dto;
using Empresa.App.Application.Interface.UseCases;
using Empresa.App.Cross.Common;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.App.Service.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitasController: ControllerBase
    {
        private readonly ICitaApplication _afiliadoApplication;
            
        public CitasController(ICitaApplication afiliadoApplication)
        {
            _afiliadoApplication = afiliadoApplication;
        }
        [HttpGet("ListCitas")]
        public async Task<ActionResult<List<CitaDTO>>> ListCitas()      
        {
            var response = await _afiliadoApplication.ListarCita();
            return response;
        }
    }
}

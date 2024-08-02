using Empresa.App.Application.Dto;
using Empresa.App.Cross.Common;

namespace Empresa.App.Application.Interface.UseCases
{
    public interface ICitaApplication   
    {

        Task<List<CitaDTO>> ListarCita();   
    }
}

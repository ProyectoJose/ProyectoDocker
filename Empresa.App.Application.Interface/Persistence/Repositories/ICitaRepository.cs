using Empresa.App.Domain;

namespace Empresa.App.Application.Interface.Persistence.Repositories
{
    public interface ICitaRepository
    {
        Task<List<Cita>> ListarCita();  
    }
}

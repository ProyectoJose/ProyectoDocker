using Dapper;
using Empresa.App.Application.Interface.Persistence.Repositories;
using Empresa.App.Domain;
using Empresa.App.Infraestructure.Persistencia.Context.Dapper;
using System.Data;

namespace Empresa.App.Infraestructure.Persistencia.Repositories
{
    public class CitaRepository: ICitaRepository
    {
        private readonly DapperContext _context;

        public CitaRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<Cita>> ListarCita()
        {
            try
            {
                using (var connection = _context.GetConnection())
                {
                    var query = "LISTA_CITA";

                    var afiliadoList = await connection.QueryAsync<Cita>(query, commandType: CommandType.StoredProcedure);
                    return (List<Cita>)afiliadoList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de datos.", ex);
            }
        }
    }
}

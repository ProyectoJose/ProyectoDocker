using Empresa.App.Service.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Empresa.App.Service.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AfiliadosController: ControllerBase
    {
        [HttpGet("ListAfiliados")]
        public List<Afiliado> ListAfiliados()
        {            
            var list = new List<Afiliado>();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "demo-sql-delete.cfqay6u8sikg.us-east-1.rds.amazonaws.com";
            builder.UserID = "admin";
            builder.Password = "Grupo1Utec";
            builder.InitialCatalog = "DB_SALUD";
            builder.TrustServerCertificate = true;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                connection.Open();

                String sql = "SELECT TOP (1000) [UNIDAD_EJECUTORA],[AMBITO_INEI],[VRAEM] ,[EDAD] ,[SEXO],[PLAN_DE_SEGURO] ,[departamento],[provincia],[distrito] FROM [DB_SALUD].[dbo].[AFILIADO]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cita = new Afiliado()
                            {
                                UnidadEjecutora = reader.GetString(0),
                                AmbitoINEI = reader.GetString(1),
                                Vraem = reader.GetString(2),
                                Edad = reader.GetString(3),
                                Sexo = reader.GetString(4),
                                PlanSeguro = reader.GetString(5),
                                Departamento = reader.GetString(6),
                                Provincia = reader.GetString(7),
                                Distrito = reader.GetString(8)                            
                            };
                            list.Add(cita);
                        }
                    }
                }
            }

            return list;
        }
    }
}

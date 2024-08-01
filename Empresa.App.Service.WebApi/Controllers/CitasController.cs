using Empresa.App.Service.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ProyectoDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitasController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CitasController> _logger;

        public CitasController(ILogger<CitasController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ListDemo1")]
        public IEnumerable<WeatherForecast> GetDemo1()
        {
            //demo4
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("ListCitas")]
        public List<Cita> ListCitas()
        {
            //demo10
            var list = new List<Cita>();
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

                String sql = "SELECT TOP 1000 institucion, numerodocumento FROM [dbo].[CITA]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cita = new Cita()
                            {
                                Institucion = reader.GetString(0),
                                Documento = reader.GetInt32(1)
                            };
                            list.Add(cita);
                        }
                    }
                }
            }

            return list;
        }

        [HttpPost("ListDemo3")]
        public List<Cita> GetDemo3()
        {
            //demo10
            var list = new List<Cita>();
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

                String sql = "SELECT TOP 1000 institucion, numerodocumento FROM [dbo].[CITA]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cita = new Cita()
                            {
                                Institucion = reader.GetString(0),
                                Documento = reader.GetInt32(1)
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


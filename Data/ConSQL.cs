using System.Data;
using System.Data.SqlClient;

namespace API_Cadastro.Data
{
    public class ConSQL
    {
        private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.json").Build();

        public static IDbConnection CreateConnection()
        {
            try
            {
                return new SqlConnection(_configuration.GetConnectionString("SQLServer"));

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
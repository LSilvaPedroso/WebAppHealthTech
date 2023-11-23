using WebAppHealthTech.Connections;
using WebAppHealthTech.Models;

namespace WebAppHealthTech.Repository
{
    public class EspecialidadeRepository
    {
        private readonly IConfiguration _configuration;
        //private readonly OracleDatabase _dbConnection;
        private readonly SqlContext _sqlConnection;


        public EspecialidadeRepository(IConfiguration configuration, SqlContext dbConnection)
        {
            _configuration = configuration;
            _sqlConnection = dbConnection;
        }
        public List<EspecialidadeModel> FindAll()
        {
            var registro = _sqlConnection.Especialidade
                    .ToList();

            return registro;
        }
    }
}

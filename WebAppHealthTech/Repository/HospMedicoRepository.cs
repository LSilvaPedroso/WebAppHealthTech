using WebAppHealthTech.Connections;
using WebAppHealthTech.Models;

namespace WebAppHealthTech.Repository
{
    public class HospMedicoRepository
    {
        private readonly IConfiguration _configuration;
        //private readonly OracleDatabase _dbConnection;
        private readonly SqlContext _sqlConnection;


        public HospMedicoRepository(IConfiguration configuration, SqlContext dbConnection)
        {
            _configuration = configuration;
            _sqlConnection = dbConnection;
        }
        public List<HospMedicoModel> FindAll()
        {
            var registro = _sqlConnection.HospMedico
                    .ToList();

            return registro;
        }
    }
}

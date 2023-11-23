using WebAppHealthTech.Connections;
using WebAppHealthTech.Models;

namespace WebAppHealthTech.Repository
{
    public class MedicoEspecRepository
    {
        private readonly IConfiguration _configuration;
        //private readonly OracleDatabase _dbConnection;
        private readonly SqlContext _sqlConnection;


        public MedicoEspecRepository(IConfiguration configuration, SqlContext dbConnection)
        {
            _configuration = configuration;
            _sqlConnection = dbConnection;
        }
        public List<MedicoEspecModel> FindAll()
        {
            var registro = _sqlConnection.MedicoEspec
                    .ToList();

            return registro;
        }
    }
}

using Microsoft.Data.SqlClient;
using WebAppHealthTech.Connections;
using WebAppHealthTech.Models;

namespace WebAppHealthTech.Repository
{
    public class PacienteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlContext _sqlConnection;

        public PacienteRepository(IConfiguration configuration, SqlContext dbConnection)
        {
            _configuration = configuration;
            _sqlConnection = dbConnection;
        }

        public PacienteRepository()
        {
        }

        public List<PacienteModel> FindAll()
        {
            var registros = _sqlConnection.Paciente
                .ToList();
            return registros;
        }

        public PacienteModel FindByEmail(string email)
        {
            var registro = _sqlConnection.Paciente
                .FirstOrDefault(m => m.PacienteEmail == email);

            return registro;
        }

        public async void AddPaciente(string PacienteName, int Cpf, string PacienteEmail, string PacienteSenha)
        {
            var registro = new PacienteModel
            {
                PacienteName = PacienteName,
                PacienteEmail = PacienteEmail,
                PacienteSenha = PacienteSenha,
                Cpf = Cpf
            };

            try
            {
                _sqlConnection.Paciente.Add(registro);
                await _sqlConnection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }

        public async void DeletePaciente(int Id)
        {

            var registro = _sqlConnection.Paciente
                .FirstOrDefault(m => m.PacienteId == Id);

            try
            {
                if (registro != null)
                {
                    _sqlConnection.Paciente.Remove(registro);
                    _sqlConnection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }

        public async void UpdatePaciente(int Id, string PacienteName, int Cpf, string PacienteEmail, string PacienteSenha)
        {

            var registro = _sqlConnection.Paciente
                .FirstOrDefault(m => m.PacienteId == Id);

            try
            {
                if (registro != null)
                {
                    registro.PacienteName = PacienteName;
                    registro.Cpf = Cpf;
                    registro.PacienteEmail = PacienteEmail;
                    registro.PacienteSenha = PacienteSenha;

                    _sqlConnection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebAppHealthTech.Connections;
using WebAppHealthTech.Models;

namespace WebAppHealthTech.Repository
{
    public class AgendaRepository
    {
        private IConfiguration _configuration;
        private SqlContext _sqlConnection;

        public AgendaRepository(IConfiguration configuration, SqlContext dbConnection)
        {
            _configuration = configuration;
            _sqlConnection = dbConnection;
        }
        public List<AgendaModel> FindAll()
        {
            var registro = _sqlConnection.Agenda
                    .ToList();

            return registro;
        }
        public string FindPacienteId(int Id)
        {
            var registro = _sqlConnection.Agenda
                    .ToList()
            .Where(cr => cr.PacienteId.Equals(Id));

            var options = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore, // Ignorar valores nulos
                Formatting = Formatting.Indented, // Formato indentado para facilitar a leitura
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(registro, options);
            return json;
        }
        public string FindId(int Id)
        {
            var registro = _sqlConnection.Agenda
                    .ToList()
            .Where(cr => cr.AgendaId.Equals(Id));

            var options = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore, // Ignorar valores nulos
                Formatting = Formatting.Indented, // Formato indentado para facilitar a leitura
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(registro, options);
            return json;
        }
        public async void AddAgenda(int PacienteId, int MedicoId, DateTime DataEntrada, DateTime DataSaida)
        {
            var registro = new AgendaModel
            {
                PacienteId = PacienteId,
                MedicoId = MedicoId,
                DataEntrada = DataEntrada,
                DataSaida = DataSaida
            };

            try
            {
                _sqlConnection.Agenda.Add(registro);
                await _sqlConnection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }

        public async void DeleteAgenda(int Id)
        {

            var registro = _sqlConnection.Agenda
                .FirstOrDefault(m => m.AgendaId == Id);

            try
            {
                if (registro != null)
                {
                    _sqlConnection.Agenda.Remove(registro);
                    _sqlConnection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }

        public async void UpdateAgenda(int Id, int PacienteId, int MedicoId, DateTime DataEntrada, DateTime DataSaida)
        {

            var registro = _sqlConnection.Agenda
                .FirstOrDefault(m => m.AgendaId == Id);

            try
            {
                if (registro != null)
                {
                    registro.PacienteId = PacienteId;
                    registro.MedicoId = MedicoId;
                    registro.DataEntrada = DataEntrada;
                    registro.DataSaida = DataSaida;

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

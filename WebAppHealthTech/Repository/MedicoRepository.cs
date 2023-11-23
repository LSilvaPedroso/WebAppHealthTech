using WebAppHealthTech.Connections;
using WebAppHealthTech.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebAppHealthTech.Repository
{
    public class MedicoRepository
    {
        private readonly IConfiguration _configuration;
        //private readonly OracleDatabase _dbConnection;
        private readonly SqlContext _sqlConnection;


        public MedicoRepository(IConfiguration configuration, SqlContext dbConnection)
        {
            _configuration = configuration;
            _sqlConnection = dbConnection;
        }
        public List<MedicoModel> FindAll()
        {
            var registros = _sqlConnection.Medico
                .ToList();
            return registros;
        }

        public async void AddMedico(string nmMedico, int nrCrm, DateTime dtContratacao, DateTime dtNascimento)
        {
            var registro = new MedicoModel
            {
                MedicoName = nmMedico,
                DataNascimento = dtNascimento,
                Crm = nrCrm,
                DataContratacao = dtContratacao,
            };

            try
            {
                _sqlConnection.Medico.Add(registro);
                await _sqlConnection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }

        public async void DeleteMedico(int Id)
        {

            var registro = _sqlConnection.Medico
                .FirstOrDefault(m => m.MedicoId == Id);

            try
            {
                if (registro != null)
                {
                    _sqlConnection.Medico.Remove(registro);
                    _sqlConnection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }

        public async void UpdateMedico(int Id, string nmMedico, int nrCrm, DateTime dtContratacao, DateTime dtNascimento)
        {

            var registro = _sqlConnection.Medico
                .FirstOrDefault(m => m.MedicoId == Id);

            try
            {
                if (registro != null)
                {
                    registro.DataContratacao = dtContratacao;
                    registro.DataNascimento = dtNascimento;
                    registro.MedicoName = nmMedico;
                    registro.Crm = nrCrm;

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

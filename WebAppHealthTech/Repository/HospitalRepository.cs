using WebAppHealthTech.Connections;
using WebAppHealthTech.Models;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace WebAppHealthTech.Repository
{
    public class HospitalRepository
    {
        private readonly IConfiguration _configuration;
        //private readonly OracleDatabase _dbConnection;
        private readonly SqlContext _sqlConnection;


        public HospitalRepository(IConfiguration configuration, SqlContext dbConnection)
        {
            _configuration = configuration;
            _sqlConnection = dbConnection;
        }
        public List<HospitalModel> FindAll()
        {
            var registro = _sqlConnection.Hospital
                    .ToList();

            return registro;
        }

        public async void AddHospital(string HospitalName, string HospitalEndereco, int Cnpj, int Cep, string Cidade, string Estado, string Uf)
        {
            var registro = new HospitalModel
            {
                HospitalName = HospitalName,
                HospitalEndereco = HospitalEndereco,
                Cnpj = Cnpj,
                Cep = Cep,
                Cidade = Cidade,
                Estado = Estado,
            };

            try
            {
                _sqlConnection.Hospital.Add(registro);
                await _sqlConnection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }

        public async void DeleteHospital(int Id)
        {

            var registro = _sqlConnection.Hospital
                .FirstOrDefault(m => m.HospitalId == Id);

            try
            {
                if (registro != null)
                {
                    _sqlConnection.Hospital.Remove(registro);
                    _sqlConnection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }

        public async void UpdateHospital(int Id, string HospitalName, string HospitalEndereco, int Cnpj, int Cep, string Cidade, string Estado, string Uf)
        {

            var registro = _sqlConnection.Hospital
                .FirstOrDefault(m => m.HospitalId == Id);

            try
            {
                if (registro != null)
                {
                    registro.HospitalName = HospitalName;
                    registro.HospitalEndereco = HospitalEndereco;
                    registro.Cnpj = Cnpj;
                    registro.Cep = Cep;
                    registro.Cidade = Cidade;
                    registro.Estado = Estado;

                    _sqlConnection.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar pessoa: " + ex.Message);
            }
        }
        public decimal CalcularDistancia(Coordenada pontoA, Coordenada pontoB)
        {
            decimal RaioTerraKm = 6371; // Raio médio da Terra em quilômetros

            var dLat = GrausParaRadianos(pontoB.Latitude - pontoA.Latitude);
            var dLon = GrausParaRadianos(pontoB.Longitude - pontoA.Longitude);

            var a = (decimal)(Math.Sin((double)(dLat / 2)) * Math.Sin((double)(dLat / 2)) +
                              Math.Cos((double)GrausParaRadianos(pontoA.Latitude)) * Math.Cos((double)GrausParaRadianos(pontoB.Latitude)) *
                              Math.Sin((double)(dLon / 2)) * Math.Sin((double)(dLon / 2)));

            var c = 2 * (decimal)Math.Atan2(Math.Sqrt((double)a), Math.Sqrt(1 - (double)a));

            var distancia = RaioTerraKm * c;

            return distancia;
        }

        private decimal GrausParaRadianos(decimal graus)
        {
            return graus * (decimal)(Math.PI / 180);
        }
    }
}

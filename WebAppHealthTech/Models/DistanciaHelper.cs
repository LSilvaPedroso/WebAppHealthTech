namespace WebAppHealthTech.Models
{
    public class DistanciaHelper
    {
        public static decimal CalcularDistancia(Coordenada pontoA, Coordenada pontoB)
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

        private static decimal GrausParaRadianos(decimal graus)
        {
            return graus * (decimal)(Math.PI / 180);
        }
    }
}

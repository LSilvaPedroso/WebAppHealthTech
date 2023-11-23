using WebAppHealthTech.Models;
using WebAppHealthTech.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppHealthTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalRepository _hospitalRepository;

        public HospitalController(HospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }
        // GET: api/<HospitalController>
        [HttpGet]
        public ActionResult<IEnumerable<HospitalModel>> Get()
        {
            try
            {
                List<HospitalModel> listaMed = _hospitalRepository.FindAll();
                return Ok(listaMed);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter todos os hospitais: {ex.Message}");
            }
        }


        // GET api/<HospitalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //[HttpGet("{lat}/{lng}")]
        //public ActionResult<IEnumerable<HospitalModel>> GetLatLong(decimal lat, decimal lng)
        //{
        //    List<HospitalModel> listaMed = _hospitalRepository.FindAll();
        //    List<HospitalModel> listaProxima = new List<HospitalModel>();

        //    Coordenada coordenadaCliente = new Coordenada();
        //    coordenadaCliente.Latitude = lat;
        //    coordenadaCliente.Longitude = lng;

        //    foreach(var item in listaMed)
        //    {
        //        Coordenada coordenadaHospital = new Coordenada();
        //        coordenadaHospital.Latitude = item.latitude;
        //        coordenadaHospital.Longitude = item.longitude;

        //        var distancia = _hospitalRepository.CalcularDistancia(coordenadaCliente, coordenadaHospital);
        //        if (distancia <= 100)
        //        {
        //            item.quilometros = distancia;
        //            listaProxima.Add(item);
        //        }
        //    }

        //    return listaProxima;
        //}

        // POST api/<HospitalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HospitalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HospitalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using WebAppHealthTech.Models;
using WebAppHealthTech.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppHealthTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteRepository _pacienteRepository;

        public PacienteController(PacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        // GET: api/<PacienteController>
        [HttpGet]
        public ActionResult<IEnumerable<PacienteModel>> Get()
        {
            var listaMed = _pacienteRepository.FindAll();
            return Ok(listaMed);
        }

        // GET api/<PacienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<PacienteController>/5
        [HttpGet("{email}")]
        public PacienteModel Get(string email)
        {
            PacienteModel paciente = _pacienteRepository.FindByEmail(email);
            return paciente;
        }

        // POST api/<PacienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

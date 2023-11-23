using Microsoft.AspNetCore.Mvc;
using WebAppHealthTech.Models;
using WebAppHealthTech.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppHealthTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaRepository _agendaRepository;

        public AgendaController(AgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }
        // GET: api/<AgendaController>
        [HttpGet]
        public ActionResult<IEnumerable<AgendaModel>> Get()
        {
            var listaMed = _agendaRepository.FindAll();
            return Ok(listaMed);
        }

        // GET api/<AgendaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var get = _agendaRepository.FindPacienteId(id);
            return get;
        }

        // POST api/<AgendaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AgendaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AgendaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

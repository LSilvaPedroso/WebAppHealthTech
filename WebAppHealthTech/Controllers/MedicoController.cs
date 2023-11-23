using WebAppHealthTech.Models;
using WebAppHealthTech.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppHealthTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoRepository _medicoRepository;

        public MedicoController(MedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }
        // GET: api/<MedicoController>
        [HttpGet]
        public ActionResult<IEnumerable<MedicoModel>> Get()
        {
            try
            {
                List<MedicoModel> pessoas = _medicoRepository.FindAll();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter todas as pessoas: {ex.Message}");
            }
        }

        // GET api/<MedicoController>/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/<MedicoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MedicoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

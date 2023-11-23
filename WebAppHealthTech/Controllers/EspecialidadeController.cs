using Microsoft.AspNetCore.Mvc;
using WebAppHealthTech.Models;
using WebAppHealthTech.Repository;

namespace WebAppHealthTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : Controller
    {
        private readonly EspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(EspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EspecialidadeModel>> Get()
        {
            try
            {
                List<EspecialidadeModel> pessoas = _especialidadeRepository.FindAll();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter todas as pessoas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

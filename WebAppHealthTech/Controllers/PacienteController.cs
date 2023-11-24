using WebAppHealthTech.Models;
using WebAppHealthTech.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppHealthTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
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

        //// POST api/<PacienteController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            PacienteModel paciente = _pacienteRepository.FindByEmail(login.Email);
            if (paciente == null)
            {
                return BadRequest("Error");
            }

            // Implemente a lógica de autenticação aqui (por exemplo, consultando o banco de dados)
            if (login.Senha == paciente.PacienteSenha)
            {
                return Ok("Success"); // Redirecione para a página inicial após o login
            }
            else
            {
                return Unauthorized("Error"); // Redirecione para a página inicial após o login
            }

            return Ok("Success");
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

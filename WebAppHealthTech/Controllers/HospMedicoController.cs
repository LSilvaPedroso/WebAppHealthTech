using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppHealthTech.Connections;
using WebAppHealthTech.Models;
using WebAppHealthTech.Repository;

namespace WebAppHealthTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospMedicoController : Controller
    {
        private readonly HospMedicoRepository _hospMedicoRepository;

        public HospMedicoController(HospMedicoRepository hospMedicoRepository)
        {
            _hospMedicoRepository = hospMedicoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HospMedicoModel>> Get()
        {
            try
            {
                List<HospMedicoModel> pessoas = _hospMedicoRepository.FindAll();
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

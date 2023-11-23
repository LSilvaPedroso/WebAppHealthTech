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
    public class MedicoEspecController : Controller
    {
        private readonly MedicoEspecRepository _medicoEspecRepository;

        public MedicoEspecController(MedicoEspecRepository medicoEspecRepository)
        {
            _medicoEspecRepository = medicoEspecRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MedicoEspecModel>> Get()
        {
            try
            {
                List<MedicoEspecModel> pessoas = _medicoEspecRepository.FindAll();
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

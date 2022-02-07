using ApiPhone.DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : ControllerBase
    {
        private readonly IPersonPhoneService _personPhoneService;
        public PersonPhoneController(IPersonPhoneService personPhoneService)
        {
            _personPhoneService = personPhoneService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
           return  Ok(_personPhoneService.GetAll());
        }

        [HttpPost]
        public IActionResult PostPhoneNumber(Models.VO.PersonPhoneVO personPhone)
        {
            var retornoCadastro = _personPhoneService.Adicionar(personPhone);
            if (retornoCadastro.Item1)
                return NoContent();
            else
                return StatusCode(400, retornoCadastro.Item2);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhoneNumber(int id)
        {
            var retortnoDelete = _personPhoneService.Remover(id);
            if (retortnoDelete.Item1)
                return NoContent();
            else
                return StatusCode(400, retortnoDelete.Item2);
        }

        [HttpPut]
        public IActionResult AtualizarPhone(Models.VO.PersonPhoneVO personPhone)
        {
            var retortnoDelete = _personPhoneService.Atualizar(personPhone);
            if (retortnoDelete.Item1)
                return NoContent();
            else
                return StatusCode(400, retortnoDelete.Item2);
        }
    }
}

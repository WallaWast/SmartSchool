using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Data;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var retorno = _repo.GetAllProfessores(true);
            return Ok(retorno);
        }

        //api/professor/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if (professor == null) return BadRequest("Professor Não encontrado");

            return Ok(professor);
        }

        //api/professor/byName?nome=NOME
        // [HttpGet("byName")]
        // public IActionResult GetByName(string nome)
        // {
        //     var professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));

        //     if (professor == null) return BadRequest("Professor Não encontrado");

        //     return Ok(professor);
        // }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);

            if (_repo.Savechanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado");
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var pro = _repo.GetProfessorById(id);
            if (pro == null) return BadRequest("Professor não encontrado");

            _repo.Update(pro);

            if (_repo.Savechanges())
            {
                return Ok(pro);
            }

            return BadRequest("Professor não atualizado");
        }

        //Atualiza Parcialmente
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var pro = _repo.GetProfessorById(id);
            if (pro == null) return BadRequest("Professor não encontrado");

            _repo.Update(pro);

            if (_repo.Savechanges())
            {
                return Ok(pro);
            }

            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pro = _repo.GetProfessorById(id);

            if (pro == null) return BadRequest("Professor não encontrado");

            _repo.Delete(pro);

            if (_repo.Savechanges())
            {
                return Ok(pro);
            }

            return BadRequest("Professor não deletado");
        }
    }
}
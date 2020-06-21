using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Data;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);

            return Ok(result);
        }

        //api/aluno/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null) return BadRequest("Aluno Não encontrado");

            return Ok(aluno);
        }

        // //api/aluno/byName?nome=NOME&sobreNome=SOBRENOME
        // [HttpGet("byName")]
        // public IActionResult GetByName(string nome, string sobreNome)
        // {
        //     var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobreNome));

        //     if (aluno == null) return BadRequest("Aluno Não encontrado");

        //     return Ok(aluno);
        // }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);

            if (_repo.Savechanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado");
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);

            if (_repo.Savechanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");
        }

        //Atualiza Parcialmente
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);

            if (_repo.Savechanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);

            if (_repo.Savechanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não deletado");
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController() { }

        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){ Id = 1, Nome= "Wallace", Sobrenome="Torres",   Telefone = "211111111" },
            new Aluno(){ Id = 2, Nome= "Andreza", Sobrenome="Carvalho", Telefone = "211142111111" },
            new Aluno(){ Id = 3, Nome= "Vanessa", Sobrenome="Carvalho", Telefone = "4442222" },
            new Aluno(){ Id = 4, Nome= "Pedro", Sobrenome="", Telefone = "33333" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        //api/aluno/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("Aluno Não encontrado");

            return Ok(aluno);
        }

        //api/aluno/byName?nome=NOME&sobreNome=SOBRENOME
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobreNome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobreNome));

            if (aluno == null) return BadRequest("Aluno Não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //Atualiza Parcialmente
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
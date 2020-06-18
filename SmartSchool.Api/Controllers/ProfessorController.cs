using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController(){}

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok("Professores: Wallace");
        }

    }
}
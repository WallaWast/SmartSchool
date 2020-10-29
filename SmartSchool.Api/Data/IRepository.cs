using System.Collections.Generic;
using System.Threading.Tasks;
using SmartSchool.Api.Helpers;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool Savechanges();

        //ALUNOS
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);

        Aluno[] GetAllAlunos(bool includeProfessor = false);

        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);

        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        //PROFSSORES
        Professor[] GetAllProfessores(bool includeAluno = false);

        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false);

        Professor GetProfessorById(int professorId, bool includeAluno = false);

    }
}
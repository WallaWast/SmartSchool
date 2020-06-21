using AutoMapper;
using SmartSchool.Api.Dtos;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            //ALUNO
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    op => op.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNascimento.PegarIdadeAtual())
                );

            CreateMap<AlunoDto, Aluno>();

            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

            //PROFESSOR
            CreateMap<Professor, ProfessorDto>()
                .ForMember(
                    dest => dest.Nome,
                    op => op.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                );

            CreateMap<ProfessorDto, Professor>();

            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
        }
    }
}
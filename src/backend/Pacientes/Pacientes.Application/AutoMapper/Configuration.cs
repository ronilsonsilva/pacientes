using AutoMapper;
using Pacientes.Domain.Entities;
using Pacientes.Domain.Shared.ViewModels;

namespace Pacientes.Application.AutoMapper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
            CreateMap<Telefone, TelefoneViewModel>().ReverseMap();
        }
    }
}

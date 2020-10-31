using AutoMapper;
using Pacientes.Application.Contracts;
using Pacientes.Domain.Contracts.Repository.Readding;
using Pacientes.Domain.Contracts.Services;
using Pacientes.Domain.Entities;
using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacientes.Application.Services
{
    public class PacienteApplication : ApplicationService<PacienteViewModel, Paciente>, IPacienteApplication
    {
        protected readonly IPacienteReadding _pacienteReadding;
        public PacienteApplication(IMapper mapper, IPacienteService service, IPacienteReadding pacienteReadding) : base(mapper, service)
        {
            _pacienteReadding = pacienteReadding;
        }

        public async Task<ICollection<PacienteViewModel>> Listar(PacienteRequest request)
        {
            return await this._pacienteReadding.Listar(request);
        }
    }
}

using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacientes.Application.Contracts
{
    public interface IPacienteApplication : IApplication<PacienteViewModel>
    {
        Task<ICollection<PacienteViewModel>> Listar(PacienteRequest request);
    }
}

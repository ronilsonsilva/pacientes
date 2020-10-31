using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacientes.Application.Contracts
{
    public interface ITelefoneApplication : IApplication<TelefoneViewModel>
    {
        Task<ICollection<TelefoneViewModel>> Listar(TelefoneRequest request);
    }
}

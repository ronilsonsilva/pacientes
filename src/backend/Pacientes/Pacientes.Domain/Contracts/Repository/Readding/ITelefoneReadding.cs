using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacientes.Domain.Contracts.Repository.Readding
{
    public interface ITelefoneReadding
    {
        Task<ICollection<TelefoneViewModel>> Listar(TelefoneRequest request);
    }
}

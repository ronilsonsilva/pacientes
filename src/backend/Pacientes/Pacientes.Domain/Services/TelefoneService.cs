using Pacientes.Domain.Contracts.Repository.Persistency;
using Pacientes.Domain.Contracts.Services;
using Pacientes.Domain.Entities;

namespace Pacientes.Domain.Services
{
    public class TelefoneService : Service<Telefone>, ITelefoneService
    {
        public TelefoneService(ITelefonePersistency persistency) : base(persistency)
        {
        }
    }
}

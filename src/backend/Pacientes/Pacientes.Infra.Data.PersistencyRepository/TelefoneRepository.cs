using Pacientes.Domain.Contracts.Repository.Persistency;
using Pacientes.Domain.Entities;
using Pacientes.Infra.Data.Context;

namespace Pacientes.Infra.Data.Repository.Persistency
{
    public class TelefoneRepository : Repository<Telefone>, ITelefonePersistency
    {
        public TelefoneRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

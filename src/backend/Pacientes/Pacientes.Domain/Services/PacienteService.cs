using Pacientes.Domain.Contracts.Repository.Persistency;
using Pacientes.Domain.Contracts.Services;
using Pacientes.Domain.Entities;

namespace Pacientes.Domain.Services
{
    public class PacienteService : Service<Paciente>, IPacienteService
    {
        public PacienteService(IPacientePersistency persistency) : base(persistency)
        {
        }
    }
}

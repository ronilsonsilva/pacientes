using Microsoft.EntityFrameworkCore;
using Pacientes.Domain.Contracts.Repository.Persistency;
using Pacientes.Domain.Entities;
using Pacientes.Infra.Data.Context;
using System.Threading.Tasks;

namespace Pacientes.Infra.Data.Repository.Persistency
{
    public class PacienteRepository : Repository<Paciente>, IPacientePersistency
    {
        public PacienteRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<Paciente> Consultar(long id)
        {
            return await this._context.Set<Paciente>()
                .Include(x => x.Telefones)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

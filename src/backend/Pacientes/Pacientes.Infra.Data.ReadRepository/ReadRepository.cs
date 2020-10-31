using Microsoft.EntityFrameworkCore;
using Pacientes.Infra.Data.Context;
using System.Data;

namespace Pacientes.Infra.Data.Repository.Readding
{
    public class ReadRepository
    {
        private readonly ApplicationContext _context;
        protected readonly IDbConnection _conexao;
        public ReadRepository(ApplicationContext context)
        {
            _context = context;
            this._conexao = context.Database.GetDbConnection();
        }
    }
}

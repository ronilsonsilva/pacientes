using Pacientes.Domain.Contracts.Repository.Persistency;
using Pacientes.Domain.Contracts.Services;
using Pacientes.Domain.Shared;
using System.Threading.Tasks;

namespace Pacientes.Domain.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : EntityBase
    {
        protected readonly IPersistency<TEntity> _repository;

        public Service(IPersistency<TEntity> persistency)
        {
            _repository = persistency;
        }

        public async Task<TEntity> Adicionar(TEntity entity)
        {
            return await this._repository.Adicionar(entity);
        }

        public async Task<TEntity> Consultar(long id)
        {
            return await this._repository.Consultar(id);
        }

        public async Task<TEntity> Editar(TEntity entity)
        {
            return await this._repository.Editar(entity);
        }

        public async Task<bool> Excluir(long id)
        {
            return await this._repository.Excluir(id);
        }
    }
}

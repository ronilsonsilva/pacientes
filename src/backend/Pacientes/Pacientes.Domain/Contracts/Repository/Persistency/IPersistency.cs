using Pacientes.Domain.Shared;
using System.Threading.Tasks;

namespace Pacientes.Domain.Contracts.Repository.Persistency
{
    public interface IPersistency<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Adicionar(TEntity entity);
        Task<TEntity> Editar(TEntity entity);
        Task<TEntity> Consultar(long id);
        Task<bool> Excluir(long id);
    }
}

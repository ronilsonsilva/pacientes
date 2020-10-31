using Pacientes.Domain.Shared;
using System.Threading.Tasks;

namespace Pacientes.Domain.Contracts.Services
{
    public interface IService<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Adicionar(TEntity entity);
        Task<TEntity> Editar(TEntity entity);
        Task<bool> Excluir(long id);
        Task<TEntity> Consultar(long id);
    }
}

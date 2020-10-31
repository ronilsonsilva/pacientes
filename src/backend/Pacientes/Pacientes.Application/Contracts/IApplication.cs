using Pacientes.Domain.Shared;
using System.Threading.Tasks;

namespace Pacientes.Application.Contracts
{
    public interface IApplication<TEntityViewModel>
    {
        Task<Response<TEntityViewModel>> Adicionar(TEntityViewModel viewModel);
        Task<Response<TEntityViewModel>> Editar(TEntityViewModel viewModel);
        Task<Response<bool>> Excluir(long id);
        Task<TEntityViewModel> Consultar(long id);
    }
}

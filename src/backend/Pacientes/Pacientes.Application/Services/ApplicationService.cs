using AutoMapper;
using Pacientes.Application.Contracts;
using Pacientes.Domain.Contracts.Services;
using Pacientes.Domain.Shared;
using System.Threading.Tasks;

namespace Pacientes.Application.Services
{
    public class ApplicationService<TEntityViewModel, TEntity> : IApplication<TEntityViewModel> where TEntityViewModel : ViewModelBase where TEntity : EntityBase
    {
        protected readonly IMapper _mapper;
        protected readonly IService<TEntity> _service;

        public ApplicationService(IMapper mapper, IService<TEntity> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public virtual async Task<Response<TEntityViewModel>> Adicionar(TEntityViewModel viewModel)
        {
            var entity = this._mapper.Map<TEntity>(viewModel);
            if (!entity.IsValid()) return new Response<TEntityViewModel>(viewModel, entity.Validators);
            await this._service.Adicionar(entity);
            return new Response<TEntityViewModel>(this._mapper.Map<TEntityViewModel>(entity));
        }

        public virtual async Task<TEntityViewModel> Consultar(long id)
        {
            var entity = await this._service.Consultar(id);
            return this._mapper.Map<TEntityViewModel>(entity);
        }

        public virtual async Task<Response<TEntityViewModel>> Editar(TEntityViewModel viewModel)
        {
            var entity = this._mapper.Map<TEntity>(viewModel);
            if (!entity.IsValid()) return new Response<TEntityViewModel>(viewModel, entity.Validators);
            await this._service.Editar(entity);
            return new Response<TEntityViewModel>(this._mapper.Map<TEntityViewModel>(entity));
        }

        public virtual async Task<Response<bool>> Excluir(long id)
        {
            return new Response<bool>(await this._service.Excluir(id));
        }
    }
}

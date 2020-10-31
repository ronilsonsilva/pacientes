using AutoMapper;
using Pacientes.Application.Contracts;
using Pacientes.Domain.Contracts.Repository.Readding;
using Pacientes.Domain.Contracts.Services;
using Pacientes.Domain.Entities;
using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacientes.Application.Services
{
    public class TelefoneApplication : ApplicationService<TelefoneViewModel, Telefone>, ITelefoneApplication
    {
        protected readonly ITelefoneReadding _telefoneReadding;
        public TelefoneApplication(IMapper mapper, ITelefoneService service, ITelefoneReadding telefoneReadding) : base(mapper, service)
        {
            _telefoneReadding = telefoneReadding;
        }

        public async Task<ICollection<TelefoneViewModel>> Listar(TelefoneRequest request)
        {
            return await this._telefoneReadding.Listar(request);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Pacientes.Application.Contracts;
using Pacientes.Domain.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacientes.WebApi.Controllers
{
    [ApiController]
    public class BaseController<TEntityViewModel> : ControllerBase where TEntityViewModel : ViewModelBase
    {
        protected readonly IApplication<TEntityViewModel> _application;

        public BaseController(IApplication<TEntityViewModel> application)
        {
            _application = application;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntityViewModel viewModel)
        {
            var result = await this._application.Adicionar(viewModel);
            return this.DefaultResponse(result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TEntityViewModel viewModel)
        {
            var result = await this._application.Editar(viewModel);
            return this.DefaultResponse(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(long id)
        {
            return this.DefaultResponse(await this._application.Consultar(id));
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(long id)
        {
            return this.DefaultResponse(await this._application.Excluir(id));
        }

        protected IActionResult DefaultResponse(Response<object> response)
        {
            return Ok(response);
        }

        protected IActionResult DefaultResponse(object entity = null)
        {
            if (entity == null) return NoContent();
            return Ok(entity);
        }

        protected IActionResult DefaultResponse(ICollection<object> entities = null)
        {
            if (entities?.Count() == 0) return NoContent();
            return Ok(entities);
        }
    }
}

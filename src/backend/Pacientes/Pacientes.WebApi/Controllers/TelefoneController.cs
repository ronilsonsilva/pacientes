using Microsoft.AspNetCore.Mvc;
using Pacientes.Application.Contracts;
using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using System.Threading.Tasks;

namespace Pacientes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : BaseController<TelefoneViewModel>
    {
        protected readonly ITelefoneApplication _telefoneApplication;
        public TelefoneController(ITelefoneApplication application) : base(application)
        {
            this._telefoneApplication = application;
        }

        [HttpPost("Listar")]
        public async Task<IActionResult> Listar([FromBody]TelefoneRequest request)
        {
            var telefones = await this._telefoneApplication.Listar(request);
            return this.DefaultResponse(telefones);
        }
    }
}

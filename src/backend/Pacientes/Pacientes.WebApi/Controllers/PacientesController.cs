using Microsoft.AspNetCore.Mvc;
using Pacientes.Application.Contracts;
using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using System.Threading.Tasks;

namespace Pacientes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : BaseController<PacienteViewModel>
    {
        protected readonly IPacienteApplication _pacienteApplication;
        public PacientesController(IPacienteApplication application) : base(application)
        {
            this._pacienteApplication = application;
        }

        [HttpPost("Listar")]
        public async Task<IActionResult> Listar([FromBody] PacienteRequest request)
        {
            var pacientes = await this._pacienteApplication.Listar(request);
            return this.DefaultResponse(pacientes);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pacientes.Application.Contracts;
using Pacientes.Application.Services;
using Pacientes.Domain.Contracts.Repository.Persistency;
using Pacientes.Domain.Contracts.Repository.Readding;
using Pacientes.Domain.Contracts.Services;
using Pacientes.Domain.Services;
using Pacientes.Infra.Data.Context;
using Pacientes.Infra.Data.Repository.Persistency;
using Pacientes.Infra.Data.Repository.Readding;

namespace Pacientes.Infra.CrossCutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configurações]

            var connection = configuration["CONNECTION_STRING:MySQL"];
            services.AddDbContext<ApplicationContext>
                (options =>
                    options.UseMySQL(connection)
                );
            services.AddScoped<ApplicationContext, ApplicationContext>();

            #endregion

            #region [Services Application]

            services.AddScoped<ITelefoneApplication, TelefoneApplication>();
            services.AddScoped<IPacienteApplication, PacienteApplication>();

            #endregion

            #region [Domain Services]

            services.AddScoped<ITelefoneService, TelefoneService>();
            services.AddScoped<IPacienteService, PacienteService>();

            #endregion

            #region [Persistence Repositories]

            services.AddScoped<ITelefonePersistency, TelefoneRepository>();
            services.AddScoped<IPacientePersistency, PacienteRepository>();

            #endregion

            #region [Reading Repositories]

            services.AddScoped<ITelefoneReadding, TelefoneReadding>();
            services.AddScoped<IPacienteReadding, PacienteReadding>();

            #endregion
        }
    }
}

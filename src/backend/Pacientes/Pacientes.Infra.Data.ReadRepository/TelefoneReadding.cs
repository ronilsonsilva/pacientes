using Dapper;
using Pacientes.Domain.Contracts.Repository.Readding;
using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using Pacientes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes.Infra.Data.Repository.Readding
{
    public class TelefoneReadding : ReadRepository, ITelefoneReadding
    {
        public TelefoneReadding(ApplicationContext context) : base(context)
        {
        }

        public async Task<ICollection<TelefoneViewModel>> Listar(TelefoneRequest request)
        {
            var query = new StringBuilder();
            query.AppendLine(@"SELECT
	                            Id, Tipo, DDD, Numero, 
                                PacienteId, DataCadastro
                            FROM Telefone");
            var parameter = new DynamicParameters();
            if (request.PacienteId.HasValue)
            {
                query.AppendLine("WHERE PacienteId = @pacienteId");
                parameter.Add("@pacienteId", request.PacienteId, DbType.Int64);
            }

            var telefones = await this._conexao.QueryAsync<TelefoneViewModel>(query.ToString(), parameter);
            return telefones?.ToList();
        }
    }
}

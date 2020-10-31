using Dapper;
using Pacientes.Domain.Contracts.Repository.Readding;
using Pacientes.Domain.Shared.Request;
using Pacientes.Domain.Shared.ViewModels;
using Pacientes.Infra.Data.Context;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes.Infra.Data.Repository.Readding
{
    public class PacienteReadding : ReadRepository, IPacienteReadding
    {
        public PacienteReadding(ApplicationContext context) : base(context)
        {
        }

        public async Task<ICollection<PacienteViewModel>> Listar(PacienteRequest request)
        {
            var query = new StringBuilder();
            query.AppendLine(@"SELECT 
	                            Id, Nome, CPF, RG, Cns,
                                DataNascimento, Sexo, NomeMae, Endereco,
                                Bairro, Cep, Estado, Cidade, DataCadastro
                            FROM Paciente");
            var parameter = new DynamicParameters();
            bool flagWhere = false;
            if (!string.IsNullOrEmpty(request.Nome))
            {
                query.AppendLine("WHERE Nome LIKE @nome");
                parameter.Add("@nome", $"%{request.Nome}%", DbType.String);
                flagWhere = true;
            }
            if (request.CPF.HasValue)
            {
                if(flagWhere)
                    query.AppendLine("OR CPF LIKE @cpf");
                else
                    query.AppendLine("WHERE CPF LIKE @cpf");
                parameter.Add("@cpf", $"%{request.CPF}%");
            }

            var pacientes = await this._conexao.QueryAsync<PacienteViewModel>(query.ToString(), parameter);
            return pacientes?.ToList();
        }
    }
}

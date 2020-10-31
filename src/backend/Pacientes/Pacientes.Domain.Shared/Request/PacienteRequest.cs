namespace Pacientes.Domain.Shared.Request
{
    public class PacienteRequest
    {
        public PacienteRequest() {}

        public PacienteRequest(string nome, long? cPF)
        {
            Nome = nome;
            CPF = cPF;
        }

        public string Nome { get; set; }
        public long? CPF { get; set; }
    }
}

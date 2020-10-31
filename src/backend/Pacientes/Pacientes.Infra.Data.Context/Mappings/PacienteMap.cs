using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacientes.Domain.Entities;

namespace Pacientes.Infra.Data.Context.Mappings
{
    public class PacienteMap : BaseMap<Paciente>
    {
        public PacienteMap(string nomeTabela = "Paciente") : base(nomeTabela)
        {

        }

        public override void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.Property(x => x.CPF)
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasMaxLength(256)
                .IsRequired();
            
            builder.Property(x => x.Cidade)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Cep)
                .IsRequired();

            builder.Property(x => x.Endereco)
                .HasMaxLength(512)
                .IsRequired();
            
            builder.Property(x => x.DataNascimento)
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.NomeMae)
                .HasMaxLength(256);

            builder.Property(x => x.Sexo)
                .IsRequired();

            base.Configure(builder);
        }
    }
}

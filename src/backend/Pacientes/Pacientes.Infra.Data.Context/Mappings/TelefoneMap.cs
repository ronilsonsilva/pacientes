using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacientes.Domain.Entities;

namespace Pacientes.Infra.Data.Context.Mappings
{
    public class TelefoneMap : BaseMap<Telefone>
    {
        public TelefoneMap(string nomeTabela = "Telefone") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.Property(x => x.Tipo)
                .IsRequired();
            
            builder.Property(x => x.PacienteId)
                .IsRequired();

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.DDD)
                .IsRequired();

            builder.HasOne(x => x.Paciente)
                .WithMany(x => x.Telefones)
                .HasForeignKey(x => x.PacienteId);

            base.Configure(builder);
        }
    }
}

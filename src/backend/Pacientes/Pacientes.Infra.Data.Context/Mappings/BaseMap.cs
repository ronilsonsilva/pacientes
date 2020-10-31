using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacientes.Domain.Shared;
using System;

namespace Pacientes.Infra.Data.Context.Mappings
{
    public class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        protected readonly string _nomeTabela;
        public BaseMap(string nomeTabela)
        {
            this._nomeTabela = nomeTabela;
        }
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(this._nomeTabela);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Ignore(x => x.Validators);
        }
    }
}

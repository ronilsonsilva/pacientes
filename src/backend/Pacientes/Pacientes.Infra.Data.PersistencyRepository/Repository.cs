using Microsoft.EntityFrameworkCore;
using Pacientes.Domain.Contracts.Repository.Persistency;
using Pacientes.Domain.Shared;
using Pacientes.Infra.Data.Context;
using System.Threading.Tasks;

namespace Pacientes.Infra.Data.Repository.Persistency
{
    public class Repository<TEntity> : IPersistency<TEntity> where TEntity : EntityBase
    {
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Adicionar(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Consultar(long id)
        {
            return await this._context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> Editar(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.Entry(entity).Property(x => x.DataCadastro).IsModified = false;
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Excluir(long id)
        {
            var entityRemover = await this.Consultar(id);
            if (entityRemover == null) return false;
            this._context.Set<TEntity>().Remove(entityRemover);
            return (await this._context.SaveChangesAsync()) > 0;
        }
    }
}

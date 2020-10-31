using FluentValidation.Results;
using System.Collections.Generic;

namespace Pacientes.Domain.Shared
{
    public class Response<T>
    {
        public bool Ok
        {
            get { return this.Errors.Count == 0; }
        }
        public T Entity { get; set; }
        public ICollection<T> Entities { get; set; }
        public ICollection<string> Errors { get; set; } = new List<string>();
        public string AllErros
        {
            get { return string.Join(".", this.Errors); }
        }
        public ICollection<string> Mensagens { get; set; } = new List<string>();
        public string AllMensagens
        {
            get { return string.Join(".", this.Mensagens); }
        }
        public Response()
        {

        }

        public Response(T entity)
        {
            Entity = entity;
        }

        public Response(ValidationResult validation)
        {
            foreach (var error in validation.Errors)
            {
                this.AddError(error.ErrorMessage);
            }
        }
        
        public Response(T entity, ValidationResult validation)
        {
            Entity = entity;
            foreach (var error in validation.Errors)
            {
                this.AddError(error.ErrorMessage);
            }
        }

        public Response(T entity, ICollection<T> entities)
        {
            Entity = entity;
            Entities = entities;
        }

        public Response(ICollection<T> entities)
        {
            Entities = entities;
        }

        public Response<T> AddError(string erro)
        {
            this.Errors.Add(erro);
            return this;
        }

        public Response<T> AddErrors(ICollection<string> errors)
        {
            foreach (var error in errors)
            {
                this.Errors.Add(error);
            }
            return this;
        }

        public Response<T> AddMensagem(string msg)
        {
            this.Mensagens.Add(msg);
            return this;
        }
    }
}

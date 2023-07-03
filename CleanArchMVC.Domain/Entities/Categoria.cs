using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Categoria : BaseEntity
    {
        public string Nome { get; private set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria(string nome)
        {
            ValidateDomain(nome);
        }

        public Categoria(long id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(nome);
        }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), 
                "Nome inválido, Nome é requerido.");

            DomainExceptionValidation.When(nome.Length < 3,
            "Nome inválido, mínimo de 3 caracteres é requirido.");

            Nome = nome;
        }

        public void Update(string nome)
        {
            ValidateDomain(nome);
        }

    }
}

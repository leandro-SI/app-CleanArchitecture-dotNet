using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Produto : BaseEntity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string Imagem { get; private set; }
        public long CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
        {
            ValidateDomain(nome, descricao, preco, estoque, imagem);
        }

        public Produto(long id, string nome, string descricao, decimal preco, int estoque, string imagem)
        {
            ValidateDomain(nome, descricao, preco, estoque, imagem);
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
        }

        private void Update(string nome, string descricao, decimal preco, int estoque, string imagem, long categoriaId)
        {
            ValidateDomain(nome, descricao, preco, estoque, imagem);
            CategoriaId = categoriaId;
        }


        private void ValidateDomain(string nome, string descricao, decimal preco, int estoque, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido, Nome é requerido.");

            DomainExceptionValidation.When(nome.Length < 3,
                "Nome inválido, mínimo de 3 caracteres é requirido.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválido, Nome é requerido.");

            DomainExceptionValidation.When(descricao.Length < 5,
                "Descrição inválido, mínimo de 5 caracteres é requirido.");

            DomainExceptionValidation.When(preco < 0, "Preço inválido.");

            DomainExceptionValidation.When(estoque < 0, "Estoque inválido.");

            DomainExceptionValidation.When(imagem?.Length > 250,
                "Imagem inválido, máximo de 250 caracteres é requirido.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Imagem = imagem;
        }


    }
}

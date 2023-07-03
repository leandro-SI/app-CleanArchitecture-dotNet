using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class ProdutoUnitTest1
    {
        [Fact]
        public void CreateProduto_WithParameters_ResultObjectValidState()
        {
            Action action = () => new Produto(1, "Produto Nome", "Descrição produto", 5.43m, 10, "idjijdiwd00kfof");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduto_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Produto(-1, "Produto Nome", "Descrição produto", 5.43m, 10, "idjijdiwd00kfof");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Id inválido.");
        }

        [Fact]
        public void CreateProduto_ShortNameValur_DomainExceptionShortName()
        {
            Action action = () => new Produto(-1, "Pr", "Descrição produto", 5.43m, 10, "idjijdiwd00kfof");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Nome inválido, mínimo de 3 caracteres é requirido.");
        }

        [Fact]
        public void CreateProduto_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Produto(-1, "", "Descrição produto", 5.43m, 10, "idjijdiwd00kfof");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Nome inválido, Nome é requerido.");
        }

        [Fact]
        public void CreateProduto_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Produto(-1, null, "Descrição produto", 5.43m, 10, "idjijdiwd00kfof");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Nome inválido, Nome é requerido.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduto_InvalidStockValue_DomainExceptionnegativeValue(int value)
        {
            Action action = () => new Produto(-1, "produto nome", "Descrição produto", 5.43m, value, "idjijdiwd00kfof");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Estoque inválido.");
        }

        [Fact]
        public void CreateProduto_InvalidPriceValue_DomainException()
        {
            Action action = () => new Produto(-1, "Produto nome", "Descrição produto", -5.43m, 10, "idjijdiwd00kfof");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Preço inválido.");
        }

        [Fact]
        public void CreateProduto_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Produto(-1, "Produto nome", "Descrição produto", 5.43m, 10, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

    }
}

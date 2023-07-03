using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoriaUnitTest1
    {
        [Fact]
        public void CreateCategory_WithParameters_ResultObjectValidState()
        {
            Action action = () => new Categoria(1, "Categoria Nome");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Categoria(-1, "Categoria Nome");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Id inv�lido.");
        }

        [Fact]
        public void CreateCategory_ShortNameValur_DomainExceptionShortName()
        {
            Action action = () => new Categoria(1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Nome inv�lido, m�nimo de 3 caracteres � requirido.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Nome inv�lido, Nome � requerido.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Categoria(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Nome inv�lido, Nome � requerido.");
        }


    }
}

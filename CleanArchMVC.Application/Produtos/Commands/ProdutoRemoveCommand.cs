using CleanArchMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Produtos.Commands
{
    public class ProdutoRemoveCommand : IRequest<Produto>
    {
        public long Id { get; set; }

        public ProdutoRemoveCommand( long id)
        {
            Id = id;
        }
    }
}

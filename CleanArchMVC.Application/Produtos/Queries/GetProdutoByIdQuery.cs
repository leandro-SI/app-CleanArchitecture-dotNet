using CleanArchMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Produtos.Queries
{
    public class GetProdutoByIdQuery : IRequest<Produto>
    {
        public long Id { get; set; }

        public GetProdutoByIdQuery(long id)
        {
            Id = id;
        }
    }
}

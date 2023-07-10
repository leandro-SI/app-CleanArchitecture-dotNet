using CleanArchMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Produtos.Queries
{
    public class GetProdutosQuery : IRequest<IEnumerable<Produto>>
    {
    }
}

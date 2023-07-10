using CleanArchMVC.Application.Produtos.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Produtos.Handlers
{
    public class ProdutoRemoveCommandHandler : IRequestHandler<ProdutoRemoveCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoRemoveCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(ProdutoRemoveCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.BuscarProdutoPorId(request.Id);

            if (produto == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            return await _produtoRepository.RemoverProduto(produto);
        }
    }
}

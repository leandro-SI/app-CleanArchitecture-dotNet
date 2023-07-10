using CleanArchMVC.Application.Produtos.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Produtos.Handlers
{
    public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUpdateCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.BuscarProduto(request.Id);

            if (produto == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            produto.Update(request.Nome, request.Descricao, request.Preco, request.Estoque, request.Imagem, request.CategoriaId);

            return await _produtoRepository.AtualizarProduto(produto);
            
        }
    }
}

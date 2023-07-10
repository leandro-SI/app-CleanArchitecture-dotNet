using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Produtos.Commands;
using CleanArchMVC.Application.Produtos.Queries;
using CleanArchMVC.Application.Services.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProdutoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProdutoDTO>> ListarProdutos()
        {
            var produtosQuery = new GetProdutosQuery();

            if (produtosQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(produtosQuery);

            return _mapper.Map<IEnumerable<ProdutoDTO>>(result);
        }

        public async Task<ProdutoDTO> BuscarProduto(long id)
        {
            var produtoQuery = new GetProdutoByIdQuery(id);

            if (produtoQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(produtoQuery);

            return _mapper.Map<ProdutoDTO>(result);

        }

        //public async Task<ProdutoDTO> BuscarProdutoCategoria(long id)
        //{
        //    var produtoQuery = new GetProdutoByIdQuery(id);

        //    if (produtoQuery == null)
        //        throw new Exception($"Entity could not be loaded.");

        //    var result = await _mediator.Send(produtoQuery);

        //    return _mapper.Map<ProdutoDTO>(result);
        //}

        public async Task CriarProduto(ProdutoDTO produtoDto)
        {
            var produtoCreateCommand = _mapper.Map<ProdutoCreateCommand>(produtoDto);
            await _mediator.Send(produtoCreateCommand);
        }

        public async Task AtualizarProduto(ProdutoDTO produtoDto)
        {
            var produtoUpdateCommand = _mapper.Map<ProdutoUpdateCommand>(produtoDto);
            await _mediator.Send(produtoUpdateCommand);
        }

        public async Task RemoverProduto(long id)
        {
            var produtoRemoveCommand = new ProdutoRemoveCommand(id);

            if (produtoRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(produtoRemoveCommand);

        }


    }
}

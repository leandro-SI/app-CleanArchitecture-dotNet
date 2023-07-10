using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Services.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProdutoService_old : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService_old(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> ListarProdutos()
        {
            var produtos = await _produtoRepository.ListarProdutos();

            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<ProdutoDTO> BuscarProduto(long id)
        {
            var produto = await _produtoRepository.BuscarProdutoPorId(id);

            return _mapper.Map<ProdutoDTO>(produto);
        }

        //public async Task<ProdutoDTO> BuscarProdutoCategoria(long id)
        //{
        //    var produto = await _produtoRepository.BuscarProdutoCategoria(id);

        //    return _mapper.Map<ProdutoDTO>(produto);
        //}

        public async Task CriarProduto(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);

            await _produtoRepository.CriarProduto(produto);
        }

        public async Task AtualizarProduto(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);

            await _produtoRepository.AtualizarProduto(produto);
        }

        public async Task RemoverProduto(long id)
        {
            var produto = await _produtoRepository.BuscarProdutoPorId(id);

            await _produtoRepository.RemoverProduto(produto);

        }
    }
}

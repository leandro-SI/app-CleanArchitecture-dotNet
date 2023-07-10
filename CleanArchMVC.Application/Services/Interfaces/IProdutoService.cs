using CleanArchMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> ListarProdutos();
        Task<ProdutoDTO> BuscarProduto(long id);
        //Task<ProdutoDTO> BuscarProdutoCategoria(long id);
        Task CriarProduto(ProdutoDTO produtoDto);
        Task AtualizarProduto(ProdutoDTO produtoDto);
        Task RemoverProduto(long id);
    }
}

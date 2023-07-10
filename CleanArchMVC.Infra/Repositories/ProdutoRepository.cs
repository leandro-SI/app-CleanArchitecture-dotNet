using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _produtoContext;

        public ProdutoRepository(ApplicationDbContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public async Task<Produto> CriarProduto(Produto produto)
        {
            _produtoContext.Produtos.Add(produto);
            await _produtoContext.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> BuscarProdutoPorId(long id)
        {
            //return await _produtoContext.Produtos.FindAsync(id);
            return await _produtoContext.Produtos.Include(p => p.Categoria)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        //public Task<Produto> BuscarProdutoCategoria(long id)
        //{
        //    return _produtoContext.Produtos.Include(p => p.Categoria)
        //        .SingleOrDefaultAsync(p => p.Id == id);
        //}

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return await _produtoContext.Produtos.ToListAsync();
        }

        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            _produtoContext.Produtos.Update(produto);
            await _produtoContext.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> RemoverProduto(Produto produto)
        {
            _produtoContext.Produtos.Remove(produto);
            await _produtoContext.SaveChangesAsync();

            return produto;
        }


    }
}

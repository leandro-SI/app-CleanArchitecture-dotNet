﻿using CleanArchMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ListarProdutos();
        Task<Produto> BuscarProduto(long id);
        Task<Produto> CriarProduto(Produto categoria);
        Task<Produto> AtualizarProduto(Produto categoria);
        Task<Produto> RemoverProduto(Produto categoria);
    }
}
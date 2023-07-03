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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _categoriaContext;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoriaContext = context;
        }

        public async Task<Categoria> CriarCategoria(Categoria categoria)
        {
            _categoriaContext.Add(categoria);
            await _categoriaContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> BuscarCategoria(long id)
        {
            return await _categoriaContext.Categorias.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            return await _categoriaContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> AtualizarCategoria(Categoria categoria)
        {
            _categoriaContext.Categorias.Update(categoria);
            await _categoriaContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> RemoverCategoria(Categoria categoria)
        {
            _categoriaContext.Categorias.Remove(categoria);
            await _categoriaContext.SaveChangesAsync();

            return categoria;
        }
    }
}

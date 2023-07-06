using CleanArchMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> ListarCategorias();
        Task<CategoriaDTO> BuscarCategoria(long id);
        Task CriarCategoria(CategoriaDTO categoriaDto);
        Task AtualizarCategoria(CategoriaDTO categoriaDto);
        Task RemoverCategoria(long id);
    }
}

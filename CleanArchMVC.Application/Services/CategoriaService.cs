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
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> ListarCategorias()
        {
            var categoriasEntity = await _repository.ListarCategorias();

            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }

        public async Task<CategoriaDTO> BuscarCategoria(long id)
        {
            var categoriaEntity = await _repository.BuscarCategoria(id);

            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task CriarCategoria(CategoriaDTO categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);

            await _repository.CriarCategoria(categoriaEntity);
        }

        public async Task AtualizarCategoria(CategoriaDTO categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);

            await _repository.AtualizarCategoria(categoriaEntity);
        }

        public async Task RemoverCategoria(long id)
        {
            var categoriaEntity = await _repository.BuscarCategoria(id);

            await _repository.RemoverCategoria(categoriaEntity);
        }
    }
}

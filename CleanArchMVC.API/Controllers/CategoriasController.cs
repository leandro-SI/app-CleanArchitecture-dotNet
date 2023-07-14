using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Services.Interfaces;
using CleanArchMVC.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriasService;

        public CategoriasController(ICategoriaService categoriasService)
        {
            _categoriasService = categoriasService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriasService.ListarCategorias();

            if (categorias == null) return NotFound("Nenhuma categoria encontrada.");

            return Ok(categorias);
        }

        [HttpGet("{id:long}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(long id)
        {
            var categoria = await _categoriasService.BuscarCategoria(id);

            if (categoria == null) return NotFound("Categoria não encontrada.");

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return BadRequest("Dados inválidos.");

            await _categoriasService.CriarCategoria(categoriaDTO);

            return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(long id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO?.Id)
                return BadRequest();

            if (categoriaDTO == null)
                return BadRequest();

            await _categoriasService.AtualizarCategoria(categoriaDTO);

            return Ok(categoriaDTO);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(long id)
        {
            var categoria = await _categoriasService.BuscarCategoria(id);

            if (categoria == null)
                return NotFound("Categoria não encontrada.");

            await _categoriasService.RemoverCategoria(id);

            return Ok(categoria);
        }

    }
}

using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _produtoService.ListarProdutos();

            if (produtos == null) return NotFound("Nenhuma produto encontrado.");

            return Ok(produtos);
        }

        [HttpGet("{id:long}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(long id)
        {
            var produto = await _produtoService.BuscarProduto(id);

            if (produto == null) return NotFound("Produto não encontrada.");

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest("Dados inválidos.");

            await _produtoService.CriarProduto(produtoDTO);

            return new CreatedAtRouteResult("GetProduto", new { id = produtoDTO.Id }, produtoDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(long id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO?.Id)
                return BadRequest();

            if (produtoDTO == null)
                return BadRequest();

            await _produtoService.AtualizarProduto(produtoDTO);

            return Ok(produtoDTO);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(long id)
        {
            var produto = await _produtoService.BuscarProduto(id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            await _produtoService.RemoverProduto(id);

            return Ok(produto);
        }

    }
}

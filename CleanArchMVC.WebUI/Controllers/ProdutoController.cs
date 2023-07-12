using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Application.Services.Interfaces;
using CleanArchMVC.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProdutoController(IProdutoService produtoService, ICategoriaService categoriaService, IWebHostEnvironment webHostEnvironment)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.ListarProdutos();

            return View(produtos);
        }

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            ViewBag.CategoriaId = new SelectList(await _categoriaService.ListarCategorias(), "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.CriarProduto(produtoDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(produtoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(long id)
        {
            if (id < 0)
                return NotFound();

            var produtoDto = await _produtoService.BuscarProduto(id);

            if (produtoDto == null) return NotFound();

            var categorias = await _categoriaService.ListarCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Nome", produtoDto.CategoriaId);

            return View(produtoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.AtualizarProduto(produtoDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(produtoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(long id)
        {
            if (id < 0) return NotFound();

            var produtoDTO = await _produtoService.BuscarProduto(id);

            if (produtoDTO == null) return NotFound();

            return View(produtoDTO);
        }

        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> ConfirmarDelete(long id)
        {
            if (id < 0) return NotFound();

            await _produtoService.RemoverProduto(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(long id)
        {
            if (id < 0) return NotFound();

            var produtoDTO = await _produtoService.BuscarProduto(id);

            if (produtoDTO == null) return NotFound();

            var wwwroot = _webHostEnvironment.WebRootPath;
            var imagem = Path.Combine(wwwroot, "images\\" + produtoDTO.Imagem);
            var exists = System.IO.File.Exists(imagem);
            ViewBag.ImagemExiste = exists;

            return View(produtoDTO);
        }

    }
}

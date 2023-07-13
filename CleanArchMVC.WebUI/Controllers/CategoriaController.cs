using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ListarCategorias();

            return View(categorias);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.CriarCategoria(categoriaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(long id)
        {
            if (id < 0) return NotFound();

            var categoriaDTO = await _categoriaService.BuscarCategoria(id);

            if (categoriaDTO == null) return NotFound();

            return View(categoriaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.AtualizarCategoria(categoriaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(long id)
        {
            if (id < 0) return NotFound();

            var categoriaDTO = await _categoriaService.BuscarCategoria(id);

            if (categoriaDTO == null) return NotFound();

            return View(categoriaDTO);
        }

        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> ConfirmarDelete(long id)
        {
            if (id < 0) return NotFound();

            await _categoriaService.RemoverCategoria(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(long id)
        {
            if (id < 0) return NotFound();

            var categoriaDTO = await _categoriaService.BuscarCategoria(id);

            if (categoriaDTO == null) return NotFound();

            return View(categoriaDTO);
        }

    }
}

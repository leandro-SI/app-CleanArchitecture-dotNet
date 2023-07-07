using CleanArchMVC.Application.Services;
using CleanArchMVC.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.ListarProdutos();

            return View(produtos);
        }
    }
}

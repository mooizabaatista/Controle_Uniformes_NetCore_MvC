using Microsoft.AspNetCore.Mvc;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Requisicao_RSS.WebUi.Controllers
{
    public class HomeController : Controller
    {
        // Injeção de dependência
        private readonly IFuncionarioService _funcionarioService;
        private readonly IRequisicaoService _requisicaoService;
        public HomeController(IFuncionarioService funcionarioService, IRequisicaoService requisicaoService)
        {
            _funcionarioService = funcionarioService;
            _requisicaoService = requisicaoService;
        }

        // Home
        [HttpGet]
        public IActionResult Index(FuncionarioDTO funcionario)
        {
            // Lista de requisições do dia atual.
            var xRequisicoes = _requisicaoService.GetRequisicoes().Result.Where(r => r.Data == DateTime.Today).ToList();
            ViewBag.Requisicoes = xRequisicoes;

            // Contagem dos funcionários do diurno e noturnos
            ViewBag.TotalDiurno = _funcionarioService.GetFuncionarios().Result.Where(x => x.Turno.ToLower() == "diurno").Count();
            ViewBag.TotalNoturno = _funcionarioService.GetFuncionarios().Result.Where(x => x.Turno.ToLower() == "noturno").Count();

            return View(funcionario);
        }

        // Campo de busca para pesquisar um funcionário
        [HttpPost]
        public async Task<IActionResult> GetFuncionario(string registro)
        {
            var xFuncionario = await _funcionarioService.GetByRegistro(registro);

            if (xFuncionario == null)
            {
                TempData["error"] = "Funcionario não Localizado.";
            }
           
            return RedirectToAction(nameof(Index), xFuncionario);
        }

    }
}

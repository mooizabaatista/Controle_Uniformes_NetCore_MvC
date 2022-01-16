using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using Requisicao_RSS.WebUi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace Requisicao_RSS.WebUi.Controllers
{
    public class RequisicoesController : Controller
    {
        // Injeção de dependência
        private readonly IRequisicaoService _requisicaoService;
        private readonly IFuncionarioService _funcionarioService;

        public RequisicoesController(IRequisicaoService requisicaoService, IFuncionarioService funcionarioService)
        {
            _requisicaoService = requisicaoService;
            _funcionarioService = funcionarioService;

        }

        // Home
        [HttpGet]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            // Lista de requisições
            var xRequisicoes = await _requisicaoService.GetRequisicoes();

            // paginando os dados recebidos
            IPagedList<RequisicaoDTO> xRequisicoesPaginadas = xRequisicoes.ToPagedList(pagina, 10);

            return View(xRequisicoesPaginadas);
        }


        // View Details ( Detalhes da requisição )
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var xRequisicao = await _requisicaoService.GetById(id);

            ViewBag.FuncionarioNome = _funcionarioService.GetById(xRequisicao.FuncionarioId).Result.Nome;

            return View(xRequisicao);
        }

        // Pesquisa para filtrar uma requisição por data específica
        [HttpPost]
        public ActionResult GetDataRequisicao(DateTime data, int pagina = 1)
        {
            var xRequisicoes = _requisicaoService.GetRequisicoes().Result.Where(r => r.Data == data).ToList();

            if (xRequisicoes.Count == 0)
            {
                var allRequisicoes = _requisicaoService.GetRequisicoes();
                TempData["error"] = "Data não localizada.";
                return RedirectToAction("Index", allRequisicoes);
            }

            IPagedList<RequisicaoDTO> allRequisicoesPaginadas = xRequisicoes.ToPagedList(pagina, 1000000);

            ViewBag.xCondition = 1;

            return View("Index", allRequisicoesPaginadas);
        }


        // Add requisição
        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            // Localizando funcionário
            var xFuncionario = await _funcionarioService.GetById(id);

            // Gera tamanho personalizado "Não trocou"
            var myTamanhos = new Tamanhos().GetTamanhos();
            myTamanhos.Add(new Tamanhos { Valor = "Não Trocou", Texto = "Não Trocou" });

            //Capturando todas as informações sobre o funcionario
            ViewBag.Registro = xFuncionario.Registro;
            ViewBag.FuncionarioId = xFuncionario.FuncionarioId;
            ViewBag.FuncionarioNome = xFuncionario.Nome;
            ViewBag.FuncionarioFuncao = xFuncionario.Funcao;
            ViewBag.TamanhosCamisa = new SelectList(myTamanhos, "Valor", "Texto", xFuncionario.BaseCamisa);
            ViewBag.TamanhosCalca = new SelectList(myTamanhos, "Valor", "Texto", xFuncionario.BaseCalca);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequisicaoDTO requisicao)
        {
            if (ModelState.IsValid)
            {
                // Verifica se já existe uma requisição para o funcionário na mesma data
                var xFuncionario = _requisicaoService.GetRequisicoes().Result.Where(r => r.Data == requisicao.Data).Where(r => r.Registro == requisicao.Registro).Count();

                if (xFuncionario > 0)
                {
                    TempData["error"] = "Funcionário já possui requisição.";
                }
                else
                {
                    await _requisicaoService.Add(requisicao);
                    TempData["success"] = "Requisição cadastrada com sucesso.";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["error"] = "Erro ao cadastrar a requisição.";
            }

            // Gera tamanho personalizado "Não trocou" novamente
            var myTamanhos = new Tamanhos().GetTamanhos();
            myTamanhos.Add(new Tamanhos { Valor = "Não Trocou", Texto = "Não Trocou" });

            // Manda novamente as informações do funcionário
            ViewBag.Registro = requisicao.Registro;
            ViewBag.FuncionarioId = requisicao.FuncionarioId;
            ViewBag.TamanhosCamisa = new SelectList(myTamanhos, "Valor", "Texto", requisicao.TamanhoCalca);
            ViewBag.TamanhosCalca = new SelectList(myTamanhos, "Valor", "Texto", requisicao.TamanhoCamisa);
            ViewBag.FuncionarioFuncao = _funcionarioService.GetById(requisicao.FuncionarioId).Result.Funcao;
            ViewBag.FuncionarioNome = _funcionarioService.GetById(requisicao.FuncionarioId).Result.Nome;

            return View(requisicao);
        }

        // Edit uma requisição
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Erro ao localizar a requisição.";
            }

            // Capturando requisicao
            var xRequisicao = await _requisicaoService.GetById(id);

            // Capturando informações sobre o funcionário
            ViewBag.FuncionarioRegistro = _funcionarioService.GetById(xRequisicao.FuncionarioId).Result.Registro;
            ViewBag.FuncionarioFuncao = _funcionarioService.GetById(xRequisicao.FuncionarioId).Result.Funcao;

            if (xRequisicao == null)
            {
                TempData["error"] = "Erro ao localizar a requisição.";
            }

            // Gera tamanho personalizado "Não trocou"
            var myTamanhos = new Tamanhos().GetTamanhos();

            myTamanhos.Add(new Tamanhos { Valor = "Não Trocou", Texto = "Não Trocou" });

            ViewBag.TamanhosCamisa = new SelectList(myTamanhos, "Valor", "Texto", xRequisicao.TamanhoCamisa);
            ViewBag.TamanhosCalca = new SelectList(myTamanhos, "Valor", "Texto", xRequisicao.TamanhoCalca);

            return View(xRequisicao);
        }


        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(RequisicaoDTO requisicao)
        {
            var myTamanhos = new Tamanhos().GetTamanhos();

            if (ModelState.IsValid)
            {
                await _requisicaoService.Update(requisicao);
                TempData["success"] = "Requisição editada com sucesso.";
                return RedirectToAction("Index", "Funcionarios");
            }
           
                TempData["error"] = "Erro ao editar a requisição.";
           

            return RedirectToAction("Index", "Funcionarios");
        }

        // Remove uma requisição

        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                TempData["error"] = "Erro ao localizar a requisição.";

            var xRequisicao = await _requisicaoService.GetById(id);

            ViewBag.NomeFuncionario = _funcionarioService.GetById(xRequisicao.FuncionarioId).Result.Nome;

            if (xRequisicao == null)
                TempData["error"] = "Erro ao localizar a requisição.";

            return View(xRequisicao);
        }

        [HttpPost(), ActionName("Remove")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _requisicaoService.Remove(id);
            TempData["success"] = "Requisição removida com sucesso.";
            return RedirectToAction("Index");
        }
    }
}

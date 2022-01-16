using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using Requisicao_RSS.WebUi.Models;
using Rotativa.AspNetCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Requisicao_RSS.WebUi.Controllers
{
    public class FuncionariosController : Controller
    {
        // Injeção de dependência
        private readonly IFuncionarioService _funcionarioService;
        private readonly IRequisicaoService _requisicaoService;

        public FuncionariosController(IFuncionarioService funcionarioService, IRequisicaoService requisicaoService)
        {
            _funcionarioService = funcionarioService;
            _requisicaoService = requisicaoService;
        }

        // Listar todos os funcionários
        [HttpGet]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            var xFuncionarios = await _funcionarioService.GetFuncionarios();

            IPagedList<FuncionarioDTO> funcionariosPaginados = xFuncionarios.ToPagedList(pagina, 10);

            return View(funcionariosPaginados);
        }


        // Campo de pesquisa para filtrar um funcionário específico
        [HttpPost]
        public ActionResult GetFuncionario(string registro, int pagina = 1)
        {
            var xFuncionario = _funcionarioService.GetFuncionarios().Result.Where(r => r.Registro == registro).ToList();

            if (xFuncionario.Count == 0)
            {
                var AllFuncionarios = _funcionarioService.GetFuncionarios();
                TempData["error"] = "Funcionário não localizado";
                return RedirectToAction("Index", AllFuncionarios);
            }

            ViewBag.xCondition = 1;

            IPagedList<FuncionarioDTO> AllFunc = xFuncionario.ToPagedList(pagina, 1);

            return View("Index", AllFunc);
        }

        // View Details ( Requisições do funcionário )
        #region Detalhes Funcionário

        // Exibe a lista de requisições de um único funcionário
        [HttpGet]
        public async Task<IActionResult> Details(int id, int pagina = 1)
        {
            var xRequisicoes = await _requisicaoService.GetRequisicoes();
            var detalhes = xRequisicoes.Where(x => x.FuncionarioId == id);


            IPagedList<RequisicaoDTO> requisicoesPaginadas = detalhes.ToPagedList(pagina, 10);

            ViewBag.FuncId = id;
            ViewBag.FuncNome = _funcionarioService.GetById(id).Result.Nome;
            ViewBag.FuncRegistro = _funcionarioService.GetById(id).Result.Registro;
            ViewBag.xCondition = 1;

            return View(requisicoesPaginadas);
        }


        // Campo de pesquisa para filtrar uma requisição por data específica
        [HttpPost]
        public ActionResult GetDataRequisicao(DateTime data, int funcId)
        {
            var xRequisicoes = _requisicaoService.GetRequisicoes().Result.Where(r => r.Data == data).Where(r => r.FuncionarioId == funcId).ToList();

            if (xRequisicoes.Count() == 0)
            {
                var AllRequisicoes = _requisicaoService.GetRequisicoes().Result.Where(r => r.FuncionarioId == funcId).ToList();

                IPagedList<RequisicaoDTO> requsicoesPaginadas = AllRequisicoes.ToPagedList();

                TempData["error"] = "Data não localizada.";
                ViewBag.FuncId = funcId;
                ViewBag.FuncNome = _funcionarioService.GetById(funcId).Result.Nome;
                ViewBag.FuncRegistro = _funcionarioService.GetById(funcId).Result.Registro;
                return View("Details", requsicoesPaginadas);
            }

            ViewBag.FuncId = funcId;
            ViewBag.FuncNome = _funcionarioService.GetById(funcId).Result.Nome;
            ViewBag.FuncRegistro = _funcionarioService.GetById(funcId).Result.Registro;

            IPagedList<RequisicaoDTO> requisicoesPaginadas = xRequisicoes.ToPagedList();

            return View("Details", requisicoesPaginadas);
        }


        // View Gerar Relatório
        // Página para gerar uma relatório em PDF com uma data inicial e uma data final
        public IActionResult RelatorioRequisicoes(int id)
        {
            ViewBag.FuncId = id;
            return View();
        }


        // Página com os dados para serem convertidos em PDF
        public IActionResult RelatorioPDF(int id, DateTime dataInicio, DateTime dataFim)
        {

            var xIdFuncionario = _funcionarioService.GetById(id).Result.FuncionarioId;

            ViewData["DataInicio"] = dataInicio.ToShortDateString();
            ViewData["DataFim"] = dataFim.ToShortDateString();
            ViewData["NomeFuncionario"] = _funcionarioService.GetById(id).Result.Nome.ToString();
           

            var xRequisicoes = _requisicaoService.GetRequisicoes().Result.Where(x => x.FuncionarioId == id).Where(x => x.Data >= dataInicio).Where(x => x.Data <= dataFim).ToList();

            return new ViewAsPdf(xRequisicoes, viewData: ViewData)
            {
                IsGrayScale = true,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 10, 0, 10),
            };
        }
        #endregion


        // Cadastrar Funcionário
        #region Cadastrar funcionário

        [HttpGet]
        public IActionResult Create()
        {
            var myTamanhos = new Tamanhos();

            // Preenchendo os tamanhos das roupas
            ViewBag.TamanhosCamisa = new SelectList(myTamanhos.GetTamanhos(), "Valor", "Texto");
            ViewBag.TamanhosCalca = new SelectList(myTamanhos.GetTamanhos(), "Valor", "Texto");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(FuncionarioDTO funcionario)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o funcionário já existe
                var xRegistro = _funcionarioService.GetFuncionarios().Result.Where(c => c.Registro == funcionario.Registro).Count();

                if (xRegistro > 0)
                {
                    TempData["error"] = "Funcionário já foi cadastrado.";
                    return RedirectToAction(nameof(Create));
                }

                // Adiciona o funcionário
                await _funcionarioService.Add(funcionario);
                TempData["success"] = "Funcionário cadastrado com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Erro ao cadastrar o funcionário.";
            }

            // Manda novamente a lista de tamanhos da roupa para a view
            var myTamanhos = new Tamanhos();
            ViewBag.TamanhosCamisa = new SelectList(myTamanhos.GetTamanhos(), "Valor", "Texto");
            ViewBag.TamanhosCalca = new SelectList(myTamanhos.GetTamanhos(), "Valor", "Texto");

            return View(funcionario);
        }
        #endregion

        // Editar funcionário
        #region Editar funcionário

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Funcionário não localizado.";
            }

            var xFuncionario = await _funcionarioService.GetById(id);

            // Preenchendo os tamanhos das roupas com o valor passado no cadastro
            var myTamanhos = new Tamanhos();
            ViewBag.TamanhosCamisa = new SelectList(myTamanhos.GetTamanhos(), "Valor", "Texto", xFuncionario.BaseCamisa);
            ViewBag.TamanhosCalca = new SelectList(myTamanhos.GetTamanhos(), "Valor", "Texto", xFuncionario.BaseCalca);

            if (xFuncionario == null)
            {
                TempData["error"] = "Funcionário não localizado.";
            }

            return View(xFuncionario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FuncionarioDTO funcionario)
        {
            if (ModelState.IsValid)
            {
                await _funcionarioService.Update(funcionario);
                TempData["success"] = "Funcionário editado com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Erro ao editar o funcionário.";
            }

            // Preenchendo novamente os tamanhos das roupas com o valor passado no cadastro
            var myTamanhos = new Tamanhos();
            ViewBag.TamanhosCamisa = new SelectList(myTamanhos.GetTamanhos(), "Valor", "Texto", funcionario.BaseCamisa);
            ViewBag.TamanhosCalca = new SelectList(myTamanhos.GetTamanhos(), "Valor", "Texto", funcionario.BaseCalca);

            return View(funcionario);
        }
        #endregion


        // Remover funcionário
        #region Remover funcionario

        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                TempData["error"] = "Funcionário não localizado.";

            var xFuncionario = await _funcionarioService.GetById(id);

            if (xFuncionario == null)
                TempData["error"] = "Funcionário não localizado.";

            return View(xFuncionario);
        }

        [HttpPost(), ActionName("Remove")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _funcionarioService.Remove(id);
            TempData["success"] = "Funcionário removido com sucesso!";
            return RedirectToAction("Index");
        }
        #endregion

    }
}

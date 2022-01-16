using Microsoft.AspNetCore.Mvc;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using Rotativa.AspNetCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Requisicao_RSS.WebUi.Controllers
{
    public class FornecedoresController : Controller
    {
        // Injeção de dependência
        private readonly IFornecedorService _fornecedorService;
        private readonly IEntregaMaterialService _entregaMaterialService;
        private readonly IRetiradaMaterialService _retiradaMaterialService;

        public FornecedoresController(IFornecedorService fornecedorService, IEntregaMaterialService entregaMaterialService, IRetiradaMaterialService retiradaMaterialService)
        {
            _fornecedorService = fornecedorService;
            _entregaMaterialService = entregaMaterialService;
            _retiradaMaterialService = retiradaMaterialService;
        }

        // Get fornecedores
        [HttpGet]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            var xFornecedores = await _fornecedorService.GetFornecedores();

            IPagedList<FornecedorDTO> AllFornec = xFornecedores.ToPagedList(pagina, 10);

            return View(AllFornec);
        }


        // Menu de opções para o fornecedor
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var xFornecedor = await _fornecedorService.GetById(id);

            ViewBag.FornId = id;
            ViewBag.NomeFornecedor = _fornecedorService.GetById(id).Result.Nome;

            return View(xFornecedor);
        }


        // Get entregas fornecedor específico
        public async Task<IActionResult> ListaEntregas(int? id, int pagina = 1)
        {
            var xEntregas = await _entregaMaterialService.GetEntregasMateriais();
            var detalhes = xEntregas.Where(x => x.FornecedorId == id);


            ViewBag.NomeFornecedor = _fornecedorService.GetById(id).Result.Nome;
            ViewBag.FornecedorId = id;

            IPagedList<EntregaMaterialDTO> aLLeEntreg = detalhes.ToPagedList(pagina, 10);

            return View(aLLeEntreg);
        }


        // Campo de pesquisa para filtrar uma entrega por data específica
        [HttpPost]
        public ActionResult GetDataEntrega(DateTime data, int fornecedorId, int pagina = 1)
        {
            var xEntregas = _entregaMaterialService.GetEntregasMateriais().Result.Where(r => r.Data == data).Where(r => r.FornecedorId == fornecedorId).ToList();

            if (xEntregas.Count == 0)
            {
                TempData["error"] = "Data não localizada.";
                var allEntregas = _entregaMaterialService.GetEntregasMateriais().Result.Where(r => r.FornecedorId == fornecedorId).ToList();


                ViewBag.FornecedorId = fornecedorId;
                ViewBag.NomeFornecedor = _fornecedorService.GetById(fornecedorId).Result.Nome;

                IPagedList<EntregaMaterialDTO> allEntregasPaginadas = allEntregas.ToPagedList(pagina, 10);

                return View("ListaEntregas", allEntregasPaginadas);
            }

            ViewBag.xCondition = 1;

            ViewBag.FornecedorId = fornecedorId;

            ViewBag.NomeFornecedor = _fornecedorService.GetById(fornecedorId).Result.Nome;

            IPagedList<EntregaMaterialDTO> entregasPaginadas = xEntregas.ToPagedList();

            return View("ListaEntregas", entregasPaginadas);
        }

        // Página de pesquisa de entregas de materiais por data de inicio e data fim para relatório em PDF
        public IActionResult RelatorioEntregas(int id)
        {
            ViewBag.FornecedorId = id;
            return View();
        }

        // Gerar Relatorio de entregas em PDF
        public IActionResult RelatorioEntregasPDF(int id, DateTime dataInicio, DateTime dataFim)
        {
            // Tentar fazer chegar a data correta

            ViewData["DataInicio"] = dataInicio.ToShortDateString();
            ViewData["DataFim"] = dataFim.ToShortDateString();
            ViewData["NomeFornecedor"] = _fornecedorService.GetById(id).Result.Nome.ToString();

            var xEntregas = _entregaMaterialService.GetEntregasMateriais().Result.Where(x => x.FornecedorId == id).Where(x => x.Data >= dataInicio).Where(x => x.Data <= dataFim).ToList();

            var xFornecedorNome = _fornecedorService.GetById(id).Result.Nome;

            return new ViewAsPdf(xEntregas, viewData: ViewData)
            {
                IsGrayScale = false,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 10, 0, 10),

            };
        }


        // Get retiradas fornecedor específico
        public async Task<IActionResult> ListaRetiradas(int? id, int pagina = 1)
        {
            var xRetiradas = await _retiradaMaterialService.GetRetiradasMateriais();
            var detalhes = xRetiradas.Where(x => x.FornecedorId == id);


            ViewBag.NomeFornecedor = _fornecedorService.GetById(id).Result.Nome;

            ViewBag.FornecedorId = id;

            IPagedList<RetiradaMaterialDTO> allRetiradas = detalhes.ToPagedList(pagina, 10);

            return View(allRetiradas);
        }


        // Campo de pesquisa para filtrar uma retirada por data específica
        [HttpPost]
        public ActionResult GetDataRetirada(DateTime data, int fornecedorId, int pagina = 1)
        {
            var xRetiradas = _retiradaMaterialService.GetRetiradasMateriais().Result.Where(r => r.Data == data).Where(r => r.FornecedorId == fornecedorId).ToList();

            if (xRetiradas.Count == 0)
            {
                TempData["error"] = "Data não localizada.";
                var allRetiradas = _retiradaMaterialService.GetRetiradasMateriais().Result.Where(r => r.FornecedorId == fornecedorId).ToList();


                ViewBag.FornecedorId = fornecedorId;
                ViewBag.NomeFornecedor = _fornecedorService.GetById(fornecedorId).Result.Nome;

                IPagedList<RetiradaMaterialDTO> allRetiradasPaginadas = allRetiradas.ToPagedList(pagina, 10);

                return View("ListaRetiradas", allRetiradasPaginadas);
            }

            ViewBag.xCondition = 1;

            ViewBag.FornecedorId = fornecedorId;

            ViewBag.NomeFornecedor = _fornecedorService.GetById(fornecedorId).Result.Nome;

            IPagedList<RetiradaMaterialDTO> retiradasPaginadas = xRetiradas.ToPagedList();

            return View("ListaRetiradas", retiradasPaginadas);
        }


        // Página de pesquisa de retirada de materiais por data de inicio e data fim para relatório em PDF
        public IActionResult RelatorioRetiradas(int id)
        {
            ViewBag.FornecedorId = id;
            return View();
        }

        // Gerar Relatorio de entregas em PDF
        public IActionResult RelatorioRetiradasPDF(int id, DateTime dataInicio, DateTime dataFim)
        {
            // Tentar fazer chegar a data correta

            ViewData["DataInicio"] = dataInicio.ToShortDateString();
            ViewData["DataFim"] = dataFim.ToShortDateString();
            ViewData["NomeFornecedor"] = _fornecedorService.GetById(id).Result.Nome.ToString();

            var xEntregas = _retiradaMaterialService.GetRetiradasMateriais().Result.Where(x => x.FornecedorId == id).Where(x => x.Data >= dataInicio).Where(x => x.Data <= dataFim).ToList();

            var xFornecedorNome = _fornecedorService.GetById(id).Result.Nome;

            return new ViewAsPdf(xEntregas, viewData: ViewData)
            {
                IsGrayScale = true,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(0, 10, 0, 10),

            };
        }




        // Add fornecedor
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FornecedorDTO fornecedorDTO)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorService.Add(fornecedorDTO);
                TempData["success"] = "Fornecedor Cadastrado com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Erro ao cadastrar o fornecedor.";
            }

            return View();
        }

        // Edit fornecedor
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var xFornecedor = await _fornecedorService.GetById(id);

            if (xFornecedor == null)
                return NotFound();

            return View(xFornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FornecedorDTO fornecedorDTO)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorService.Update(fornecedorDTO);
                TempData["success"] = "Fornecedor editado com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Erro ao editar o fornecedor.";
            }

            return View(fornecedorDTO);
        }

        // Remove fornecedor
        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                TempData["error"] = "Erro ao localizar o fornecedor";

            var xFornecedor = await _fornecedorService.GetById(id);

            if (xFornecedor == null)
                TempData["error"] = "Erro ao localizar o fornecedor";

            return View(xFornecedor);
        }

        [HttpPost(), ActionName("Remove")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _fornecedorService.Remove(id);
            TempData["success"] = "Fornecedor removido com sucesso.";
            return RedirectToAction("Index");
        }
    }
}

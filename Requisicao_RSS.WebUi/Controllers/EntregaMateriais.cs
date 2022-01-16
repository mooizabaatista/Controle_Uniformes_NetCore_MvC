using Microsoft.AspNetCore.Mvc;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Requisicao_RSS.WebUi.Controllers
{
    public class EntregaMateriaisController : Controller
    {
        // Injeção de dependência
        private readonly IEntregaMaterialService _entregaMaterialService;
        private readonly IFornecedorService _fornecedorService;

        public EntregaMateriaisController(IEntregaMaterialService entregaMaterialService, IFornecedorService fornecedorService)
        {
            _entregaMaterialService = entregaMaterialService;
            _fornecedorService = fornecedorService;
        }

        // Lista todas as entregas
        [HttpGet]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            // Arrumar paginação
            var xEntregas = await _entregaMaterialService.GetEntregasMateriais();

            IPagedList<EntregaMaterialDTO> xEntregasPaginadas = xEntregas.ToPagedList(pagina, 10);

            return View(xEntregasPaginadas);
        }

        // Filtrar entrega por data específica
        [HttpPost]
        public ActionResult GetDataEntregas(DateTime data)
        {
            var xEntregas = _entregaMaterialService.GetEntregasMateriais().Result.Where(r => r.Data == data).ToList();

            if (xEntregas.Count == 0)
            {
                var AllEntregas = _entregaMaterialService.GetEntregasMateriais();
                TempData["error"] = "Data não localizada.";
                return RedirectToAction("Index", AllEntregas);
            }

            return View("Index", xEntregas);
        }

        // Detalhes de uma entrega específica ( View Details )
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var xEntregas = await _entregaMaterialService.GetById(id);


            return View(xEntregas);

        }


        // Cadastrar Entrega
        #region Cadastrar Entrega

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
                TempData["error"] = "Erro ao localizar o fornecedor.";

            var xFornecedor = await _fornecedorService.GetById(id);

            ViewBag.FornecedorId = xFornecedor.FornecedorId;

            ViewBag.FornecedorNome = xFornecedor.Nome;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EntregaMaterialDTO entregaMaterial)
        {
            if (ModelState.IsValid)
            {
                await _entregaMaterialService.Add(entregaMaterial);
                TempData["success"] = "Entrega cadastrada com sucesso.";
                return RedirectToAction("Index", "Fornecedores");
            }
            else
            {
                TempData["error"] = "Erro ao cadastrar a entrega.";
            }

            var xFornecedor = await _fornecedorService.GetById(entregaMaterial.FornecedorId);

            ViewBag.FornecedorId = xFornecedor.FornecedorId;

            ViewBag.FornecedorNome = xFornecedor.Nome;

            return View(entregaMaterial);

        }
        #endregion

        // Editar entrega
        #region Editar entrega

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Erro ao cadastrar a entrega.";
            }

            var xEntregaMaterial = await _entregaMaterialService.GetById(id);

            ViewBag.FornecedorNome = _fornecedorService.GetById(xEntregaMaterial.FornecedorId).Result.Nome;

            if (xEntregaMaterial == null)
            {
                return NotFound();
            }


            return View(xEntregaMaterial);
        }


        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(EntregaMaterialDTO entregaMaterial)
        {

            if (ModelState.IsValid)
            {
                await _entregaMaterialService.Update(entregaMaterial);
                TempData["success"] = "Entrega editada com sucesso.";
                return RedirectToAction("ListaEntregas", "Fornecedores", new { @id = entregaMaterial.FornecedorId });
            }
            else
            {
                ViewBag.FornecedorNome = _fornecedorService.GetById(entregaMaterial.FornecedorId).Result.Nome;
                TempData["error"] = "Erro ao editar a entrega.";
            }

            return View(entregaMaterial);
        }
        #endregion

        // Remover entrega
        #region Remover entrega

        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                TempData["error"] = "Erro ao localizar a entrega.";

            var xEntrega = await _entregaMaterialService.GetById(id);

            if (xEntrega == null)
                TempData["error"] = "Erro ao localizar a entrega.";

            return View(xEntrega);
        }

        [HttpPost(), ActionName("Remove")]
        public async Task<IActionResult> DeleteConfirmed(int id, int fornecedorId)
        {
            await _entregaMaterialService.Remove(id);

            var xFornecedorId = _fornecedorService.GetById(fornecedorId).Result.FornecedorId;

            TempData["success"] = "Entrega removida com sucesso.";
            return RedirectToAction("ListaEntregas", "Fornecedores", new { @id = xFornecedorId });
        }
        #endregion
    }
}

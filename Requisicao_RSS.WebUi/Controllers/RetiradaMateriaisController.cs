using Microsoft.AspNetCore.Mvc;
using Requisicao_RSS.Application.DTOs;
using Requisicao_RSS.Application.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Requisicao_RSS.WebUi.Controllers
{
    public class RetiradaMateriaisController : Controller
    {
        // Injeção de dependência
        private readonly IRetiradaMaterialService _retiradaMaterialService;
        private readonly IFornecedorService _fornecedorService;

        public RetiradaMateriaisController(IRetiradaMaterialService retiradaaMaterialService, IFornecedorService fornecedorService)
        {
            _retiradaMaterialService = retiradaaMaterialService;
            _fornecedorService = fornecedorService;
        }

        // GetAll retiradas de materiais
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var xRetiradas = await _retiradaMaterialService.GetRetiradasMateriais();


            return View(xRetiradas);
        }

        // Campo para filtrar uma retirada em uma data específica
        [HttpPost]
        public ActionResult GetDataRetiradas(DateTime data)
        {
            var xRetiradas = _retiradaMaterialService.GetRetiradasMateriais().Result.Where(r => r.Data == data).ToList();

            if (xRetiradas.Count == 0)
            {
                var AllRetiradas = _retiradaMaterialService.GetRetiradasMateriais();
                TempData["error"] = "Data não localizada.";
                
                return RedirectToAction("Index", AllRetiradas);
            }

            return View("Index", xRetiradas);
        }

        // Detalhes de uma retirada específica
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var xEntregas = await _retiradaMaterialService.GetById(id);


            return View(xEntregas);

        }


        // Add retirada de materiais
        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
                TempData["error"] = "Erro ao localizar a retirada.";

            // Localiza um fornecedor
            var xFornecedor = await _fornecedorService.GetById(id);

            // Captura informações do fornecedor 
            ViewBag.FornecedorId = xFornecedor.FornecedorId;
            ViewBag.FornecedorNome = xFornecedor.Nome;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RetiradaMaterialDTO retiradaMaterial)
        {            
            if (ModelState.IsValid)
            {
                await _retiradaMaterialService.Add(retiradaMaterial);
                TempData["success"] = "Retirada cadastrada com sucesso.";
                return RedirectToAction("Index", "Fornecedores");
            }
            else
            {
                TempData["error"] = "Erro ao cadastrar a retirada.";
            }

            // Manda novamente informações do fornecedor
            ViewBag.FornecedorNome = retiradaMaterial.NomeFornecedor;
            ViewBag.FornecedorId = retiradaMaterial.FornecedorId;

            return View(retiradaMaterial);

        }


        // Edit retirada de material
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["error"] = "Erro ao localizar a retirada.";
            }

            var xRetiradaMaterial = await _retiradaMaterialService.GetById(id);

            if (xRetiradaMaterial == null)
            {
                return NotFound();
            }

            return View(xRetiradaMaterial);
        }


        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(RetiradaMaterialDTO retiradaMaterial)
        {
            if (ModelState.IsValid)
            {
                await _retiradaMaterialService.Update(retiradaMaterial);
                TempData["success"] = "Retirada editada com sucesso.";
                return RedirectToAction("ListaRetiradas", "Fornecedores", new { @id = retiradaMaterial.FornecedorId });
            }
            else
            {
                TempData["error"] = "Erro ao editar a retirada.";
            }

            // Localiza o fornecedor
            var xFornecedor = await _fornecedorService.GetById(retiradaMaterial.FornecedorId);

            // Captura informações do fornecedor
            ViewBag.FornecedorNome = retiradaMaterial.NomeFornecedor;

            return View(retiradaMaterial);
        }


        // Remove retirada de material
        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                TempData["error"] = "Erro ao localizar a retirada.";

            var xRetirada = await _retiradaMaterialService.GetById(id);

            if (xRetirada == null)
                TempData["error"] = "Erro ao localizar a retirada.";

            return View(xRetirada);
        }

        [HttpPost(), ActionName("Remove")]
        public async Task<IActionResult> DeleteConfirmed(int id, int fornecedorId)
        {
            await _retiradaMaterialService.Remove(id);

            var xFornecedorId = _fornecedorService.GetById(fornecedorId).Result.FornecedorId;

            TempData["success"] = "Retirada removida com sucesso.";
            return RedirectToAction("ListaRetiradas", "Fornecedores", new { @id = xFornecedorId });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Requisicao_RSS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisicao_RSS.WebUi.Controllers
{
    public class GraficosController : Controller
    {
        // Injeção de dependência
        private readonly IRequisicaoService _requisicaoService;

        public GraficosController(IRequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

        // Informações sobre a contagem das roupas
        public IActionResult Index()
        {

            ViewBag.QtdCalcaP = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCalca == "P").Count();
            ViewBag.QtdCalcaM = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCalca == "M").Count();
            ViewBag.QtdCalcaG = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCalca == "G").Count();
            ViewBag.QtdCalcaGG = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCalca == "GG").Count();
            ViewBag.QtdCalcaXG = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCalca == "XG").Count();


            ViewBag.QtdCamisaP = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCamisa == "P").Count();
            ViewBag.QtdCamisaM = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCamisa == "M").Count();
            ViewBag.QtdCamisaG = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCamisa == "G").Count();
            ViewBag.QtdCamisaGG = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCamisa == "GG").Count();
            ViewBag.QtdCamisaXG = _requisicaoService.GetRequisicoes().Result.Where(c => c.TamanhoCamisa == "XG").Count();

            return View();
        }
    }
}

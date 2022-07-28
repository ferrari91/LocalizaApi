using Localiza.Data.Models;
using Localiza.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Localiza.Web.Controllers
{
    public class LocaçãoController : Controller
    {
        private ServiceLocação _Service = new ServiceLocação();

        public IActionResult Index()
        {
            List<TabLocacao> _lista = _Service._Repository.SelecionarTodos();

            var veiculos = new List<SelectListItem>();
            foreach (var item in _Service._Repository.Veiculos())
            {
                veiculos.Add(new SelectListItem() { Value = item.IdVeiculo.ToString(), Text = $"{item.CodigoMarcaNavigation.Modelo} Placa: {item.Placa}" });
            }

            ViewBag.CodigoMarca = veiculos;
            return View(_lista);
        }

        public IActionResult Create()
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            var veiculos = new List<SelectListItem>();
            foreach (var item in _Service._Repository.Veiculos())
            {
                veiculos.Add(new SelectListItem() { Value = item.IdVeiculo.ToString(), Text = $"{item.CodigoMarcaNavigation.Modelo} Placa: {item.Placa}" });
            }

            ViewBag.CodigoVeiculo = veiculos;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TabLocacao obj)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            _Service._Repository.Incluir(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            var cliente = _Service._Repository.SelecionarPrimaryKey(id);
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            var veiculos = new List<SelectListItem>();
            foreach (var item in _Service._Repository.Veiculos())
            {
                veiculos.Add(new SelectListItem() { Value = item.IdVeiculo.ToString(), Text = $"{item.CodigoMarcaNavigation.Modelo} Placa: {item.Placa}" });
            }

            ViewBag.CodigoVeiculo = veiculos;
            var cliente = _Service._Repository.SelecionarPrimaryKey(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(TabLocacao obj)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var veiculos = new List<SelectListItem>();
            foreach (var item in _Service._Repository.Veiculos())
            {
                veiculos.Add(new SelectListItem() { Value = item.IdVeiculo.ToString(), Text = $"{item.CodigoMarcaNavigation.Modelo} Placa: {item.Placa}" });
            }

            ViewBag.CodigoVeiculo = veiculos;

            _Service._Repository.Editar(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            _Service._Repository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}

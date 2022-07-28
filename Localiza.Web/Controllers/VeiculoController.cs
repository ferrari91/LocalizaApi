using Localiza.Data.Models;
using Localiza.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Localiza.Web.Controllers
{
    public class VeiculoController : Controller
    {
        private ServiceVeiculo _ServiceVeiculo = new ServiceVeiculo();

        public IActionResult Index()
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            List<TabVeiculo> _VeiculosLista = _ServiceVeiculo._Repository.SelecionarTodos();

            var modelos = new List<SelectListItem>();
            foreach (var item in _ServiceVeiculo._Repository.ModelosMarcas())
            {
                modelos.Add(new SelectListItem() { Value = item.IdMarca.ToString(), Text = $"Marca: {item.Marca} Modelo: {item.Modelo}" });
            }

            ViewBag.CodigoMarca = modelos;

           

            return View(_VeiculosLista);
        }

        public IActionResult Create()
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            var modelos = new List<SelectListItem>();
            foreach (var item in _ServiceVeiculo._Repository.ModelosMarcas())
            {
                modelos.Add(new SelectListItem() { Value = item.IdMarca.ToString(), Text = $"Marca: {item.Marca} Modelo: {item.Modelo}" });
            }

            ViewBag.CodigoMarca = modelos;

            ViewBag.Combustivel = new List<SelectListItem>
            {
                new SelectListItem{ Text="Gasolina", Value="Gasolina"},
                new SelectListItem{ Text="Álcool", Value="Álcool"},
                new SelectListItem{ Text="Diesel", Value="Diesel"},
            };

            ViewBag.Categoria = new SelectListItem[]
            {
                new SelectListItem() { Value = "Básico", Text = "Básico" },
                new SelectListItem() { Value = "Completo", Text = "Completo" },
                new SelectListItem() { Value = "Luxo", Text = "Luxo" },
            };

            return View();
        }

        [HttpPost]
        public IActionResult Create(TabVeiculo obj)
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
            _ServiceVeiculo._Repository.Incluir(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            var cliente = _ServiceVeiculo._Repository.SelecionarPrimaryKey(id);
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            var modelos = new List<SelectListItem>();
            foreach (var item in _ServiceVeiculo._Repository.ModelosMarcas())
            {
                modelos.Add(new SelectListItem() { Value = item.IdMarca.ToString(), Text = $"Marca: {item.Marca} Modelo: {item.Modelo}" });
            }

            ViewBag.CodigoMarca = modelos;

            ViewBag.Combustivel = new SelectListItem[] {
                new SelectListItem() { Value = "Gasolina", Text = "Gasolina" },
                 new SelectListItem() { Value = "Álcool", Text = "Álcool" },
                  new SelectListItem() { Value = "Diesel", Text = "Diesel" },
                };

            ViewBag.Categoria = new SelectListItem[]
            {
                new SelectListItem() { Value = "Básico", Text = "Básico" },
                new SelectListItem() { Value = "Completo", Text = "Completo" },
                new SelectListItem() { Value = "Luxo", Text = "Luxo" },
            };

            var cliente = _ServiceVeiculo._Repository.SelecionarPrimaryKey(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(TabVeiculo obj)
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

            var modelos = new List<SelectListItem>();
            foreach (var item in _ServiceVeiculo._Repository.ModelosMarcas())
            {
                modelos.Add(new SelectListItem() { Value = item.IdMarca.ToString(), Text = $"Marca: {item.Marca} Modelo: {item.Modelo}" });
            }

            ViewBag.CodigoMarca = modelos;

            _ServiceVeiculo._Repository.Editar(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            _ServiceVeiculo._Repository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}

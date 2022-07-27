using Localiza.Data.Models;
using Localiza.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Web.Controllers
{

    public class ClienteController : Controller
    {
        private ServiceCliente _ServiceCliente = new ServiceCliente();

        public IActionResult Index()
        {
            List<TabCliente> _ClienteLista = _ServiceCliente._Repository.SelecionarTodos();
            return View(_ClienteLista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TabCliente obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _ServiceCliente._Repository.Incluir(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var cliente = _ServiceCliente._Repository.SelecionarPrimaryKey(id);

            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var cliente         = _ServiceCliente._Repository.SelecionarPrimaryKey(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(TabCliente obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _ServiceCliente._Repository.Editar(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _ServiceCliente._Repository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}

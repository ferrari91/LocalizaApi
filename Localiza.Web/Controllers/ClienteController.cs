using Localiza.Data.Models;
using Localiza.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Localiza.Web.Controllers
{

    public class ClienteController : Controller
    {
        private ServiceCliente _ServiceCliente = new ServiceCliente();

        public IActionResult Index()
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            List<TabCliente> _ClienteLista = _ServiceCliente._Repository.SelecionarTodos();
            return View(_ClienteLista);
        }

        public IActionResult Create()
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }


           

            return View();
        }

        [HttpPost]
        public IActionResult Create(TabCliente obj)
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
            _ServiceCliente._Repository.Incluir(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            var cliente = _ServiceCliente._Repository.SelecionarPrimaryKey(id);

            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            var cliente = _ServiceCliente._Repository.SelecionarPrimaryKey(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(TabCliente obj)
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
            _ServiceCliente._Repository.Editar(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            _ServiceCliente._Repository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}

using Localiza.Data.Models;
using Localiza.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Web.Controllers
{
    public class VeiculoModeloController : Controller
    {
        private ServiceVeiculoModelo _Service = new ServiceVeiculoModelo();

        public IActionResult Index()
        {
            var acessado = HttpContext.Session.GetString("User");
            if (String.IsNullOrEmpty(acessado))
            {
                return RedirectToAction("Index", "Acesso");
            }

            List<TbVeiculoModelo> _ClienteLista = _Service._Repository.SelecionarTodos();
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
        public IActionResult Create(TbVeiculoModelo obj)
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

            var cliente = _Service._Repository.SelecionarPrimaryKey(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(TbVeiculoModelo obj)
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

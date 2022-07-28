using Localiza.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Web.Controllers
{
    public class AcessoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Acessar(string Nome, string Senha)
        {
             ServiceCliente _ServiceCliente = new ServiceCliente();
            var permitido = _ServiceCliente._Repository.Acesso(Nome, Senha);

            if (permitido)
            {
                HttpContext.Session.SetString("User", Nome);
                return RedirectToAction("Index", "Home");
            }
            
            return RedirectToAction("Index");
    }
}
}

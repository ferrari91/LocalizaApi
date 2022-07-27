using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Localiza.Web.Views.Acesso
{
    public class IndexModel : PageModel
    {
        public string Nome { get; set; }

        public string Senha { get; set; }

        public void OnGet()
        {
        }
    }
}

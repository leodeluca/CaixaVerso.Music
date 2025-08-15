using Microsoft.AspNetCore.Mvc;

namespace CaixaVerso.MusicApp.Controllers
{
    public class ErrosController : Controller
    {
        [Route("Erros/Status/{code}")]
        public IActionResult Status(int code)
        {
            if (code == 404)
                return View("~/Views/Shared/Errors/NotFound.cshtml");

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}

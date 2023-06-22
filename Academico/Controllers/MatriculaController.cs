using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class MatriculaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ECommerce.App.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

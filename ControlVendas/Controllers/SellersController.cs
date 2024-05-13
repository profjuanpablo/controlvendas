using Microsoft.AspNetCore.Mvc;

namespace ControlVendas.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using ControlVendas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlVendas.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService department) { 
            _sellerService = sellerService;
            _departmentService = department;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAll();
            return View(list);
        }


    }
}

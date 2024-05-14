using ControlVendas.Models;
using ControlVendas.Models.ViewModels;
using ControlVendas.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<IActionResult> Create() { 
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            if (id == null) {
                return RedirectToAction(nameof(Index));
            }

            var obj = await _sellerService.FindByIdAsync(id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(obj);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _sellerService.RemoveAsync(id.Value);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }




    }
}

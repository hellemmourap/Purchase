using Microsoft.AspNetCore.Mvc;
using Purchase.Data;
using Purchase.Models;
using System.Linq;

namespace Purchase.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationContext _context;

        public SupplierController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupplierModel supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }
    }
}

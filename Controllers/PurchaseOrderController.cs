using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Purchase.Data;
using Purchase.Models;
using System.Linq;

namespace Purchase.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly ApplicationContext _context;

        public PurchaseOrderController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var purchaseOrders = _context.PurchaseOrders.Include(po => po.Supplier).ToList();
            return View(purchaseOrders);
        }

        public IActionResult Create()
        {
            ViewBag.Suppliers = _context.Suppliers.ToList();
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseOrder purchaseOrder)
        {
            purchaseOrder.CreationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (purchaseOrder.Items == null || !purchaseOrder.Items.Any())
                {
                    ModelState.AddModelError("", "O pedido deve conter pelo menos um item.");
                    ViewBag.Suppliers = _context.Suppliers.ToList();
                    ViewBag.Products = _context.Products.ToList();
                    return View(purchaseOrder);
                }
                
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }

            ViewBag.Suppliers = _context.Suppliers.ToList();
            ViewBag.Products = _context.Products.ToList();
            return View(purchaseOrder);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = _context.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            if (purchaseOrder.Status == "Finalizado")
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Products = _context.Products.ToList();

            return View(purchaseOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(purchaseOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrder);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            if (purchaseOrder.Status == "Finalizado")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(purchaseOrder);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            _context.PurchaseOrders.Remove(purchaseOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.PurchaseOrders.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Helpers;
using Shop.Models;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SHOPContext _context;

        public ProductsController(SHOPContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var sHOPContext = _context.TblProduct.Include(t => t.Category);
            return View(await sHOPContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.TblCategory, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CategoryId,ProductName,ProductColor,ProductPrice,ProductSize,ProductQty,IsFeatured,Image")] TblProduct tblProduct,IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if(Image!=null)
                {
                    tblProduct.Image= FileHelper.Upload(Image);
                }
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TblCategory, "CategoryId", "CategoryName", tblProduct.CategoryId);
            return View(tblProduct);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TblCategory, "CategoryId", "CategoryName", tblProduct.CategoryId);
            return View(tblProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CategoryId,ProductName,ProductColor,ProductPrice,ProductSize,ProductQty,IsFeatured,Image")] TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.TblCategory, "CategoryId", "CategoryName", tblProduct.CategoryId);
            return View(tblProduct);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProduct = await _context.TblProduct.FindAsync(id);
            _context.TblProduct.Remove(tblProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(int id)
        {
            return _context.TblProduct.Any(e => e.ProductId == id);
        }
    }
}

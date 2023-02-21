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
    public class CategoriesController : Controller
    {
        private readonly SHOPContext _context;

        public CategoriesController(SHOPContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblCategory.ToListAsync());
        }

     

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Image")] TblCategory tblCategory,IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if(Image!=null)
                {
                    tblCategory.Image= FileHelper.Upload(Image);
                }
                _context.Add(tblCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCategory);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategory = await _context.TblCategory.FindAsync(id);
            if (tblCategory == null)
            {
                return NotFound();
            }
            return View(tblCategory);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Image")] TblCategory tblCategory,IFormFile image)
        {
            if (id != tblCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    FileHelper.Delete(tblCategory.Image);
                    tblCategory.Image = FileHelper.Upload(image);
                    _context.Update(tblCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCategoryExists(tblCategory.CategoryId))
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
            return View(tblCategory);
        }


        // POST: Categories/Delete/5
       
        public async Task<IActionResult> Delete(int id)
        {
            var tblCategory = await _context.TblCategory.FindAsync(id);
            _context.TblCategory.Remove(tblCategory);
            await _context.SaveChangesAsync();
            FileHelper.Delete(tblCategory.Image);
            return RedirectToAction(nameof(Index));
        }

        private bool TblCategoryExists(int id)
        {
            return _context.TblCategory.Any(e => e.CategoryId == id);
        }
    }
}

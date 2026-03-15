using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuDomain.Model;
using RestaurantMenuInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenuInfrastructure.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BdrestaurantMenuContext _context;

        public ProductsController(BdrestaurantMenuContext context)
        {
            _context = context;
        }

        // GET: Products

        public async Task<IActionResult> Index(int? id, string? name)
        {
      
            if (id == null) return RedirectToAction("Index", "Categories");

           
            if (string.IsNullOrEmpty(name))
            {
                var category = await _context.Category.FindAsync(id);
                name = category?.Name ?? "Категорія";
            }

            ViewBag.CategoryId = id;
            ViewBag.CategoryName = name;

         
            var productByCategory = _context.Product
                .Where(b => b.Categoriesid == id)
                .Include(b => b.Categories);

            return View(await productByCategory.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
           
            ViewData["Categoriesid"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Product product)
        {
           
            ModelState.Remove("Category");

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

               
                return RedirectToAction("Index", "Home");
            }

            ViewData["Categoryid"] = new SelectList(_context.Category, "Id", "Name", product.Categoriesid);
            return View(product);
        }
        // GET: Products/Edit/5
        // ProductsController.cs
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Product.FindAsync(id);
            if (product == null) return NotFound();

          
            ViewData["Categoriesid"] = new SelectList(_context.Category, "Id", "Name", product.Categoriesid);

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Categoriesid,Img")] Product product, IFormFile? upload)
        {
            if (id != product.Id) return NotFound();

            ModelState.Remove("Categories");

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = await _context.Product.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    if (existingProduct == null) return NotFound();

                    if (upload != null && upload.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await upload.CopyToAsync(stream);
                        }
                        product.Img = "/images/" + fileName;
                    }
                    else
                    {
                        product.Img = existingProduct.Img;
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();

                   
                    return RedirectToAction("Index", new { id = product.Categoriesid });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id)) return NotFound();
                    else throw;
                }
            }

           
            ViewData["Categoriesid"] = new SelectList(_context.Category, "Id", "Name", product.Categoriesid);
            return View(product);
        }


        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}

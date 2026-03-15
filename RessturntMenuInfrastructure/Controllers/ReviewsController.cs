using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuDomain.Model;
using RestaurantMenuInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantMenuInfrastructure.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly BdrestaurantMenuContext _context;

        public ReviewsController(BdrestaurantMenuContext context)
        {
            _context = context;
        }

        // GET: Reviews/Index/5

        public async Task<IActionResult> Index(int? id) // id — це ID продукту
        {
            if (id == null) return NotFound();

           
            var product = await _context.Product.FindAsync(id);

            if (product != null)
            {
               
                ViewBag.CategoryId = product.Categoriesid;
                ViewBag.ProductId = id;
            }

            var reviews = _context.Review
                .Where(r => r.Productsid == id)
                .Include(r => r.Products);

            return View(await reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var review = await _context.Review
                .Include(r => r.Products)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (review == null) return NotFound();

            return View(review);
        }

        // GET: Reviews/Create
     
        public IActionResult Create(int productId)
        {
            if (productId == 0)
            {
                return BadRequest("ID продукту не передано");
            }


            ViewBag.Productsid = productId;
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
  
        public async Task<IActionResult> Create([Bind("Mark,Comment,Productsid")] Review review)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            review.UserId = userId;
            review.Data = DateTime.Now;

            ModelState.Remove("Products");
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = review.Productsid });
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var review = await _context.Review.FindAsync(id);
            if (review == null) return NotFound();

            ViewData["Productsid"] = new SelectList(_context.Product, "Id", "Name", review.Productsid);
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Mark,Comment,Productsid")] Review review)
        {
            if (id != review.Id) return NotFound();

            ModelState.Remove("Products");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index), new { id = review.Productsid });
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var review = await _context.Review
                .Include(r => r.Products)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (review == null) return NotFound();

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.FindAsync(id);
            int? productId = review?.Productsid;

            if (review != null)
            {
                _context.Review.Remove(review);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index), new { id = productId });
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
    }
}
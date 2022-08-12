using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Web.Data;
using Restaurant.Web.Models;

namespace Restaurant.Web.Areas.Demos.Controllers
{
    [Area("Demos")]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Demos/Items
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Items.Include(i => i.ItemCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Demos/Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ItemCategory)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Demos/Items/Create
        public IActionResult Create()
        {
            ViewData["ItemCategoryId"] = new SelectList(_context.ItemCategories, "ItemCategoryId", "ItemCategoryName");
            return View();
        }

        // POST: Demos/Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,ItemType,ItemDescription,IsAvailable,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,ItemCategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                bool isFound = _context.Items.Any(i => i.ItemName == item.ItemName);
                if (isFound)
                {
                    ModelState.AddModelError("ItemName", "Duplicate Item Found");
                }
                else
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["ItemCategoryId"] = new SelectList(_context.ItemCategories, "ItemCategoryId", "ItemCategoryName", item.ItemCategoryId);
            return View(item);
        }

        // GET: Demos/Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ItemCategoryId"] = new SelectList(_context.ItemCategories, "ItemCategoryId", "ItemCategoryName", item.ItemCategoryId);
            return View(item);
        }

        // POST: Demos/Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,ItemType,ItemDescription,IsAvailable,Price,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,ItemCategoryId")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool isFound = await _context.Items
                                .AnyAsync(i => i.ItemId != item.ItemId
                                && i.ItemName != item.ItemName);
                if (isFound)
                {
                    ModelState.AddModelError("ItemName", "Duplicate Item Found");
                }
                else
                {
                    try
                    {
                        _context.Update(item);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ItemExists(item.ItemId))
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
            }
            ViewData["ItemCategoryId"] = new SelectList(_context.ItemCategories, "ItemCategoryId", "ItemCategoryName", item.ItemCategoryId);
            return View(item);
        }

        // GET: Demos/Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ItemCategory)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Demos/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}

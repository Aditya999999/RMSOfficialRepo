using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurant.Web.Data;
using Restaurant.Web.Models;

namespace Restaurant.Web.Areas.Demos.Controllers
{
    [Area("Demos")]
    public class ItemCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ItemCategoriesController> _logger;

        public ItemCategoriesController(ApplicationDbContext context,
                                        ILogger<ItemCategoriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Demos/ItemCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItemCategories.Include(i => i.Menu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Demos/ItemCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories
                .Include(i => i.Menu)
                .FirstOrDefaultAsync(m => m.ItemCategoryId == id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // GET: Demos/ItemCategories/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuName");
            return View();
        }

        // POST: Demos/ItemCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemCategoryId,ItemCategoryName,IsAvailable,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,ItemsAvailable,MenuId")] ItemCategory itemCategory)
        {
           

            if (ModelState.IsValid)
            {
                bool isFound = _context.ItemCategories.Any(c => c.ItemCategoryName == itemCategory.ItemCategoryName);
                if (isFound)
                {
                    ModelState.AddModelError("ItemCategoryName", "Duplicate Item Category Found");
                }
                else
                {
                    _context.Add(itemCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuName", itemCategory.MenuId);
            return View(itemCategory);
        }

        // GET: Demos/ItemCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuName", itemCategory.MenuId);
            return View(itemCategory);
        }

        // POST: Demos/ItemCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemCategoryId,ItemCategoryName,IsAvailable,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,ItemsAvailable,MenuId")] ItemCategory itemCategory)
        {
            if (id != itemCategory.ItemCategoryId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                bool isFound = await _context.ItemCategories
                                                .AnyAsync(c => c.ItemCategoryId != itemCategory.ItemCategoryId
                                                && c.ItemCategoryName == itemCategory.ItemCategoryName);
                if (isFound)
                {
                    ModelState.AddModelError("ItemCategoryName", "Duplicate Item category Found!!");
                }
                else
                {
                    try
                    {
                        _context.Update(itemCategory);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ItemCategoryExists(itemCategory.ItemCategoryId))
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
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuName", itemCategory.MenuId);
            return View(itemCategory);
        }

        // GET: Demos/ItemCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories
                .Include(i => i.Menu)
                .FirstOrDefaultAsync(m => m.ItemCategoryId == id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // POST: Demos/ItemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemCategory = await _context.ItemCategories.FindAsync(id);
            _context.ItemCategories.Remove(itemCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCategoryExists(int id)
        {
            return _context.ItemCategories.Any(e => e.ItemCategoryId == id);
        }
    }
}

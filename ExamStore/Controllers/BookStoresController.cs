using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamStore.Data;
using ExamStore.Models;

namespace ExamStore.Controllers
{
    public class BookStoresController : Controller
    {
        private readonly ExamStoreContext _context;

        public BookStoresController(ExamStoreContext context)
        {
            _context = context;
        }

        // GET: BookStores
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookStore.ToListAsync());
        }

        public async Task<IActionResult> bookOrder()
        {
            return View(await _context.BookStore.ToListAsync());
        }


        // GET: BookStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookStore = await _context.BookStore
                .FirstOrDefaultAsync(m => m.id == id);
            if (bookStore == null)
            {
                return NotFound();
            }

            return View(bookStore);
        }

        // GET: BookStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookStores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,bookName,authorName,publishedYear,Price")] BookStore bookStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookStore);
        }

        // GET: BookStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookStore = await _context.BookStore.FindAsync(id);
            if (bookStore == null)
            {
                return NotFound();
            }
            return View(bookStore);
        }

        // POST: BookStores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,bookName,authorName,publishedYear,Price")] BookStore bookStore)
        {
            if (id != bookStore.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookStoreExists(bookStore.id))
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
            return View(bookStore);
        }

        // GET: BookStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookStore = await _context.BookStore
                .FirstOrDefaultAsync(m => m.id == id);
            if (bookStore == null)
            {
                return NotFound();
            }

            return View(bookStore);
        }

        // POST: BookStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookStore = await _context.BookStore.FindAsync(id);
            _context.BookStore.Remove(bookStore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookStoreExists(int id)
        {
            return _context.BookStore.Any(e => e.id == id);
        }
    }
}

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
    public class OrderPlacesController : Controller
    {
        private readonly ExamStoreContext _context;

        public OrderPlacesController(ExamStoreContext context)
        {
            _context = context;
        }

        // GET: OrderPlaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderPlace.ToListAsync());
        }



        // GET: OrderPlaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPlace = await _context.OrderPlace
                .FirstOrDefaultAsync(m => m.id == id);
            if (orderPlace == null)
            {
                return NotFound();
            }

            return View(orderPlace);
        }

        // GET: OrderPlaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderPlaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,bookName,Qty,Price,dTime")] OrderPlace orderPlace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderPlace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderPlace);
        }

        // GET: OrderPlaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPlace = await _context.OrderPlace.FindAsync(id);
            if (orderPlace == null)
            {
                return NotFound();
            }
            return View(orderPlace);
        }

        // POST: OrderPlaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,bookName,Qty,Price,dTime")] OrderPlace orderPlace)
        {
            if (id != orderPlace.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderPlaceExists(orderPlace.id))
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
            return View(orderPlace);
        }

        // GET: OrderPlaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPlace = await _context.OrderPlace
                .FirstOrDefaultAsync(m => m.id == id);
            if (orderPlace == null)
            {
                return NotFound();
            }

            return View(orderPlace);
        }

        // POST: OrderPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderPlace = await _context.OrderPlace.FindAsync(id);
            _context.OrderPlace.Remove(orderPlace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderPlaceExists(int id)
        {
            return _context.OrderPlace.Any(e => e.id == id);
        }
    }
}

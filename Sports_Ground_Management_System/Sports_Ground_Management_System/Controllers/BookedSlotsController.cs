using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sports_Ground_Management_System.Models;

namespace Sports_Ground_Management_System.Controllers
{
    [Authorize(Roles = "User")]
    public class BookedSlotsController : Controller
    {
        private readonly MyAppDbContext _context;

        public BookedSlotsController(MyAppDbContext context)
        {
            _context = context;
        }

        // GET: BookedSlots
        public async Task<IActionResult> Index()
        {
            var myAppDbContext = _context.BookedSlot.Include(b => b.Ground);
            return View(await myAppDbContext.ToListAsync());
        }

        // GET: BookedSlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedSlot = await _context.BookedSlot
                .Include(b => b.Ground)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookedSlot == null)
            {
                return NotFound();
            }

            return View(bookedSlot);
        }

        // GET: BookedSlots/Create
        public IActionResult Create()
        {
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name");
            return View();
        }

        // POST: BookedSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,From,To,GroundId")] BookedSlot bookedSlot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookedSlot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", bookedSlot.GroundId);
            return View(bookedSlot);
        }

        // GET: BookedSlots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedSlot = await _context.BookedSlot.FindAsync(id);
            if (bookedSlot == null)
            {
                return NotFound();
            }
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", bookedSlot.GroundId);
            return View(bookedSlot);
        }

        // POST: BookedSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,From,To,GroundId")] BookedSlot bookedSlot)
        {
            if (id != bookedSlot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookedSlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookedSlotExists(bookedSlot.Id))
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
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", bookedSlot.GroundId);
            return View(bookedSlot);
        }

        // GET: BookedSlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedSlot = await _context.BookedSlot
                .Include(b => b.Ground)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookedSlot == null)
            {
                return NotFound();
            }

            return View(bookedSlot);
        }

        // POST: BookedSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookedSlot = await _context.BookedSlot.FindAsync(id);
            _context.BookedSlot.Remove(bookedSlot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookedSlotExists(int id)
        {
            return _context.BookedSlot.Any(e => e.Id == id);
        }
    }
}

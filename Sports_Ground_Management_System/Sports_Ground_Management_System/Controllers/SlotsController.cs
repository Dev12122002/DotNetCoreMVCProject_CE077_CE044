using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sports_Ground_Management_System.Areas.Identity.Data;
using Sports_Ground_Management_System.Models;

namespace Sports_Ground_Management_System.Controllers
{
    public class SlotsController : Controller
    {
        private readonly MyAppDbContext _context;

        public SlotsController(MyAppDbContext context)
        {
            _context = context;
        }

        // GET: Slots
        public async Task<IActionResult> Index()
        {
            var myAppDbContext = _context.BookedSlot.Include(s => s.Ground).Include(s => s.User);
            return View(await myAppDbContext.ToListAsync());
        }

        // GET: Slots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.BookedSlot
                .Include(s => s.Ground)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // GET: Slots/Create
        public IActionResult Create()
        {
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Set<AspNetUsers>(), "Id", "Id");
            return View();
        }

        // POST: Slots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,From,To,Attendees,GroundId,UserId")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", slot.GroundId);
            ViewData["UserId"] = new SelectList(_context.Set<AspNetUsers>(), "Id", "Id", slot.UserId);
            return View(slot);
        }

        // GET: Slots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.BookedSlot.FindAsync(id);
            if (slot == null)
            {
                return NotFound();
            }
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", slot.GroundId);
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", slot.UserId);
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,From,To,Attendees,GroundId,UserId")] Slot slot)
        {
            if (id != slot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotExists(slot.Id))
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
            ViewData["GroundId"] = new SelectList(_context.Ground, "Id", "Name", slot.GroundId);
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", slot.UserId);
            return View(slot);
        }

        // GET: Slots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.BookedSlot
                .Include(s => s.Ground)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // POST: Slots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slot = await _context.BookedSlot.FindAsync(id);
            _context.BookedSlot.Remove(slot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotExists(int id)
        {
            return _context.BookedSlot.Any(e => e.Id == id);
        }
    }
}

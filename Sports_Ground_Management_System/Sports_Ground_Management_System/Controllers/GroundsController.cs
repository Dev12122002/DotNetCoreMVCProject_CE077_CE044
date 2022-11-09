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
    [Authorize(Roles = "Admin")]
    public class GroundsController : Controller
    {
        private readonly MyAppDbContext _context;

        public GroundsController(MyAppDbContext context)
        {
            _context = context;
        }

        // GET: Grounds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ground.ToListAsync());
        }

        // GET: Grounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ground = await _context.Ground
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ground == null)
            {
                return NotFound();
            }

            return View(ground);
        }

        // GET: Grounds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grounds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,img,address,capacity")] Ground ground)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ground);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ground);
        }

        // GET: Grounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ground = await _context.Ground.FindAsync(id);
            if (ground == null)
            {
                return NotFound();
            }
            return View(ground);
        }

        // POST: Grounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,img,address,capacity")] Ground ground)
        {
            if (id != ground.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ground);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroundExists(ground.Id))
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
            return View(ground);
        }

        // GET: Grounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ground = await _context.Ground
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ground == null)
            {
                return NotFound();
            }

            return View(ground);
        }

        // POST: Grounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ground = await _context.Ground.FindAsync(id);
            _context.Ground.Remove(ground);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroundExists(int id)
        {
            return _context.Ground.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FriendsMVC.Models;

namespace FriendsMVC.Controllers
{
    public class FriendController : Controller
    {
        private readonly FriendDbContext _context;

        public FriendController(FriendDbContext context)
        {
            _context = context;
        }

        // GET: Friend
        public async Task<IActionResult> Index()
        {
              return View(await _context.Friends.ToListAsync());
        }

        // GET: Friend/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends
                .FirstOrDefaultAsync(m => m.FriendID == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // GET: Friend/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendID,FriendName,Place")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        // GET: Friend/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }
            return View(friend);
        }

        // POST: Friend/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendID,FriendName,Place")] Friend friend)
        {
            if (id != friend.FriendID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendExists(friend.FriendID))
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
            return View(friend);
        }

        // GET: Friend/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends
                .FirstOrDefaultAsync(m => m.FriendID == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Friends == null)
            {
                return Problem("Entity set 'FriendDbContext.Friends'  is null.");
            }
            var friend = await _context.Friends.FindAsync(id);
            if (friend != null)
            {
                _context.Friends.Remove(friend);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendExists(int id)
        {
          return _context.Friends.Any(e => e.FriendID == id);
        }
    }
}

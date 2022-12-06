using FriendsMVC.Buisness.Contract.Interfaces;
using FriendsMVC.DataAccess;
using FriendsMVC.DataAccess.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendsMVC.Controllers
{
    public class FriendController : Controller
    {
        private readonly FriendDbContext _context;
        private IFriendService _ifriendService;

        public FriendController(FriendDbContext context, IFriendService friendService)
        {
            _context = context;
            _ifriendService = friendService;
        }

        // GET: Friend
        public async Task<IActionResult> Index()
        {
            return View(await _ifriendService.GetFriends());
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
            if (!ModelState.IsValid) return BadRequest();
            _context.Add(friend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                _context.Update(friend);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendExists(friend.FriendID))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
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

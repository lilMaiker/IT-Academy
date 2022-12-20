using FriendsMVC.Buisness.Contract.Interfaces;
using FriendsMVC.DataAccess;
using FriendsMVC.DataAccess.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendsMVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ICountryService _countryService;

        public CountryController(ApplicationDbContext context, ICountryService countryService)
        {
            _context = context;
            _countryService = countryService;
        }

        // GET: Country/Italy/Rome/Venice
        [HttpGet("сountry/{country}/{*cities}")]
        public async Task<IActionResult> GetPopulation(string country, string cities)
        {
            if (country is not null && cities is not null)
            {
                string[] cityArray = cities.Split('/');
                return View(await _countryService.GetCountries(country, cityArray));
            }
            else if (country is not null && cities is null)
                return View(await _countryService.GetCountries(country));
            else
                return View(await _countryService.GetCountries());
        }

        // GET: Country
        public async Task<IActionResult> Index()
        {
            return View(await _countryService.GetCountries());
        }

        // GET: Country/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Countries == null)
                return NotFound();

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryID == id);

            if (country == null)
                return NotFound();

            return View(country);
        }

        // GET: Country/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryID,CountryName,CityForCountry,Population")] Country country)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Add(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Country/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Countries == null)
                return NotFound();

            var country = await _context.Countries.FindAsync(id);
            if (country == null) return NotFound();

            return View(country);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryID,CountryName,CityForCountry,Population")] Country country)
        {
            if (id != country.CountryID) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                _context.Update(country);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(country.CountryID))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Country/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Countries == null) return NotFound();

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryID == id);

            if (country == null) return NotFound();

            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Countries == null) return Problem("Entity set 'ApplicationDbContext.Countries'  is null.");

            var country = await _context.Countries.FindAsync(id);

            if (country != null) _context.Countries.Remove(country);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.CountryID == id);
        }
    }
}

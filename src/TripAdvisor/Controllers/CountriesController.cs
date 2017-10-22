using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripAdvisor.Data;
using TripAdvisor.Models;
using TripAdvisor.Models.CountryViewModels;
using TripAdvisor.Models.CityViewModels;

namespace TripAdvisor.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Countries
        public async Task<IActionResult> Index(CountryIndexViewModel viewModel)
        {
            DbSet<Country> countries = _context.Countries;
            
            viewModel.CountriesGrouping = countries.Where(objCountry =>
                (viewModel.CommonReligionFilter == null || objCountry.CommonReligion == viewModel.CommonReligionFilter) &&
                (viewModel.ContinentFilter == null || objCountry.Continent == viewModel.ContinentFilter) &&
                (viewModel.JewsAttitudeFilter == null || objCountry.AttitudeForJews <= viewModel.JewsAttitudeFilter)).Include(x => x.Cities)
                .GroupBy(x=>x.Continent);
            viewModel.Continents = Enum.GetValues(typeof(Continent));         

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_FilteredCountries", viewModel);
            }

            viewModel.TopCountries = countries.Take(5).ToList().OrderBy(x =>
            {
                if (x.Cities == null)
                    return 0;
                else return x.Cities.Count;
            }).Take(5).ToList();

            viewModel.JesAttitudes = Enum.GetValues(typeof(JewsAttitude));
            
            viewModel.CommonReligions = Enum.GetValues(typeof(CommonReligion));


            return View(viewModel);
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index","Cities",new CityIndexViewModel() {CountryFilter = id });
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AttitudeForJews,CommonReligion,Continent,Description,ImageSrc,Name,ShortDesription")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.SingleOrDefaultAsync(m => m.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AttitudeForJews,CommonReligion,Continent,Description,ImageSrc,Name,ShortDesription")] Country country)
        {
            if (id != country.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.SingleOrDefaultAsync(m => m.ID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Countries.SingleOrDefaultAsync(m => m.ID == id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.ID == id);
        }
    }
}

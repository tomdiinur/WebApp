using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripAdvisor.Data;
using TripAdvisor.Models;
using TripAdvisor.Models.CityViewModels;

namespace TripAdvisor.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cities && Search
        public async Task<IActionResult> Index(CityIndexViewModel viewModel)
        {
            
            DbSet<City> cities = _context.Cities;

            DbSet<Country> countries = _context.Countries;

            viewModel.Countries = countries.GroupBy(X => X.Continent);


            viewModel.CitiesGrouping = cities.Where(objCity =>
                (viewModel.CountryFilter == null || objCity.Country.ID == viewModel.CountryFilter) &&
                (viewModel.CitySpecialityFilter == null || objCity.CitySpeciality == viewModel.CitySpecialityFilter) &&
                (viewModel.MaxDailyExpence == null || objCity.DailyExpence <= viewModel.MaxDailyExpence)).ToList()
                .Join(countries, objCity => objCity.CountryID, objCountry => objCountry.ID, (objCity, objCountry) =>
            {
                objCity.Country = objCountry;

                return objCity;
            }).GroupBy(x => x.Country);


            viewModel.TopCities = cities.Take(5).ToList().OrderBy(x =>
            {
                if(x.Attractions == null)
                    return 0;
                else return x.Attractions.Count;
            }).Take(5).ToList();

            viewModel.CitySpecialities = Enum.GetValues(typeof(CitySpeciality));
          
                
            
            return View(viewModel);
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.SingleOrDefaultAsync(m => m.ID == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CityName,Continent,Country,Description,ImageSrc")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.SingleOrDefaultAsync(m => m.ID == id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CityName,Continent,Country,Description,ImageSrc")] City city)
        {
            if (id != city.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.ID))
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
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.SingleOrDefaultAsync(m => m.ID == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.Cities.SingleOrDefaultAsync(m => m.ID == id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.ID == id);
        }
    }
}

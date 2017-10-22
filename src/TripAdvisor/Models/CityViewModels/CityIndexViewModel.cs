using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripAdvisor.Models.CityViewModels
{
    public class CityIndexViewModel
    {
       public IEnumerable<IGrouping<Country, City>> CitiesGrouping { get; set; }

        public Array CitySpecialities { get; set; }

        public List<City> TopCities { get; set; }

        public IEnumerable<IGrouping<Continent, Country>> Countries { get; set; }

        public int? CountryFilter { get; set; }

        public CitySpeciality? CitySpecialityFilter { get; set; }

        public int? MaxDailyExpence { get; set; }
    }
}

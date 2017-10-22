using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripAdvisor.Models.CountryViewModels
{
    public class CountryIndexViewModel
    {
        public IEnumerable<IGrouping<Continent, Country>> CountriesGrouping { get; set; }

        public List<Country> TopCountries { get; set; }

        public Array Continents { get; set; }

        public Array CommonReligions { get; set; }

        public Array JesAttitudes { get; set; }

        public CommonReligion? CommonReligionFilter { get; set; }

        public JewsAttitude? JewsAttitudeFilter { get; set; }

        public Continent? ContinentFilter { get; set; }
    }
}

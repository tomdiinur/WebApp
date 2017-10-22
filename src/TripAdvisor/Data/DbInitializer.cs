using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisor.Models;

namespace TripAdvisor.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // ----------------------------------------------------
            // Initializing the countries  
            // ----------------------------------------------------

            #region Coutries

            if (!context.Countries.Any())
            {
                var countries = new Country[]
                {
                    //country id = 1
                    new Country {
                        Name = "Israel",
                        Continent = Continent.Asia,
                        Description = "Within its small perimeter, Israel packs in abundant riches, from cherished religious sites and plentiful archaeological treasures to spectacular natural wonders.",
                        AttitudeForJews = JewsAttitude.Pro,
                        CommonReligion= CommonReligion.Judaism,
                        ShortDesription = "The Promise Land",
                        ImageSrc = "http://funinthesuntraveltours.co.za/wp-content/uploads/2016/08/Israel-2-900x400.jpg"
                    },
                    
                    // id = 2
                    new Country {
                        Name = "Italy",
                        Continent = Continent.Europe,
                        Description = "Italy, a European country with a long Mediterranean coastline, has left a powerful mark on Western culture and cuisine. Its capital, Rome, is home to the Vatican as well as landmark art and ancient ruins.",
                        AttitudeForJews = JewsAttitude.Neuteral,
                        CommonReligion= CommonReligion.Christianity,
                        ShortDesription = "The Most Toured Country In The World",
                        ImageSrc = "https://www.homeaway.co.uk/files/live/sites/hr/files/shared/new%20hips/banner-images2/group-italy1.jpg"
                    },

                    // id = 3
                    new Country {
                        Name = "Spain",
                        Continent = Continent.Europe,
                        Description = "Spain, a country on Europe’s Iberian Peninsula, includes 17 autonomous regions with diverse geography and cultures. Capital city Madrid is home to the Royal Palace and Prado museum, housing works by European masters. ",
                        AttitudeForJews = JewsAttitude.Neuteral,
                        CommonReligion= CommonReligion.Christianity,
                        ShortDesription = "Origin Of THe Alhambra Decree",
                        ImageSrc = "http://orbitravel.com/images/barcelona2.jpg"
                    },

                    // id = 4
                    new Country {
                        Name = "England",
                        Continent = Continent.Europe,
                        Description = "England, birthplace of Shakespeare and The Beatles, is a country in the British Isles bordering Scotland and Wales. The capital, London, on the River Thames, is home of Parliament, Big Ben and the 11th-century Tower of London.",
                        AttitudeForJews = JewsAttitude.Neuteral,
                        CommonReligion= CommonReligion.Christianity,
                        ShortDesription = "The Home Of The Crown",
                        ImageSrc = "http://www.airfares.com.sg/promotions/qatar-airways/img/slider/london-bridge.jpg"
                    },

                    // id = 5
                    new Country {
                        Name = "France",
                        Continent = Continent.Europe,
                        Description = "France, in Western Europe, encompasses medieval cities, alpine villages and Mediterranean beaches. Paris, its capital, is famed for its fashion houses, classical art museums including the Louvre and monuments like the Eiffel Tower.",
                        AttitudeForJews = JewsAttitude.Neuteral,
                        CommonReligion= CommonReligion.Christianity,
                        ShortDesription = "Home Of The French Revolution",
                        ImageSrc = "http://puntodominios.com/wp-content/uploads/2013/02/paris.jpg"
                    },

                    // id = 6
                    new Country {
                        Name = "USA",
                        Continent = Continent.America,
                        Description = "The U.S. is a country of 50 states covering a vast swath of North America, with Alaska in the northwest and Hawaii extending the nation’s presence into the Pacific Ocean. ",
                        AttitudeForJews = JewsAttitude.Pro,
                        CommonReligion= CommonReligion.Christianity,
                        ShortDesription = "The Promise Land",
                        ImageSrc = "https://www.ncl.com/sites/default/files/NYC-gallery-900x400-02.jpg"
                    },

                    // id = 7
                    new Country {
                        Name = "India",
                        Continent = Continent.Asia,
                        Description = "India is a vast South Asian country with diverse terrain – from Himalayan peaks to Indian Ocean coastline – and history reaching back 5 millennia. In the north, Mughal Empire landmarks include Delhi’s Red Fort complex and massive Jama Masjid mosque, plus Agra’s iconic Taj Mahal mausoleum. ",
                        AttitudeForJews = JewsAttitude.Neuteral,
                        CommonReligion= CommonReligion.Hindi,
                        ShortDesription = "The Promise Land",
                        ImageSrc = "http://www.top10destination.com/wp-content/uploads/2015/10/Taj-Mahal-Agra.jpg"
                    }
              };

                foreach (var c in countries)
                {
                    context.Countries.Add(c);
                }
                context.SaveChanges();

            }

            #endregion

            // ----------------------------------------------------
            // Look for any Cities.
            // ----------------------------------------------------

            #region Cities

            if (!context.Cities.Any())
            {
                var cities = new City[]
              {
                  // city id = 1
                  new City {
                    CityName = "Rome",
                    ImageSrc = "http://www.civitavecchiacabservice.com/new/wp-content/uploads/2015/04/tour3.jpg",
                    Safety = LifeSafety.Safe,
                    ShortDescription = "City Of The Vatican",
                    Description = "Rome (Roma), the eternal city, is literally eternal. It has endured for over 2,700 years, with an ambiance like no other. Embedded in centuries of history and culture, it is Italy's capital and largest city, offering far too much to see in one visit.",
                    CountryID = 2,
                    CitySpeciality = CitySpeciality.Architecture,
                    DailyExpence = 400
                },
                  // city id = 2
                 new City {
                    CityName = "Florence",
                    ImageSrc = "http://www.antilogvacations.com/Images%5CHome%5CSubdestinations%5CInternational%5CInternational-Italy-Florence.jpg",
                    Safety = LifeSafety.Safe,
                    ShortDescription = "Home Of The Renaissance",
                    Description = "Florence, capital of Italy’s Tuscany region, is home to many masterpieces of Renaissance art and architecture. One of its most iconic sights is the Duomo, a cathedral with a terracotta-tiled dome engineered by Brunelleschi and a bell tower by Giotto. ",
                    CountryID = 2,
                    CitySpeciality = CitySpeciality.Architecture,
                    DailyExpence = 300
                },
                 // 3
                  new City {
                    CityName = "Venesia",
                    ImageSrc = "https://www.ncl.com/sites/default/files/PortGalleries.Venice.Canals1.jpg",
                    Safety = LifeSafety.Safe,
                    ShortDescription = "The Capital Of Northern Italy",
                    Description = "Venice, the capital of northern Italy’s Veneto region, is built on more than 100 small islands in a lagoon in the Adriatic Sea. It has no roads, just canals – including the Grand Canal thoroughfare – lined with Renaissance and Gothic palaces. ",
                    CountryID = 2,
                    CitySpeciality = CitySpeciality.Architecture,
                    DailyExpence = 100
                },
                  // city id = 4
                  new City {
                    CityName = "Milan",
                    ImageSrc = "http://i0.wp.com/www.maltacheaptravels.com/wp-content/uploads/2016/09/expo-2014-milan-by-night.jpg?resize=900%2C400",
                    Safety = LifeSafety.Safe,
                    ShortDescription = "Capital Of Fsahion",
                    Description = "Milan, a metropolis in Italy's northern Lombardy region, is a global capital of fashion and design. Home to the national stock exchange, it’s a financial hub also known for its high-end restaurants and shops.",
                    CountryID = 2,
                    CitySpeciality = CitySpeciality.Modern,
                    DailyExpence = 600
                },
                  // 5
                new City {
                    CityName = "Barcelona",
                    ImageSrc = "https://www.ncl.com/sites/default/files/PortGalleries.Barcelona.ParcGuell2.jpg",
                    Safety = LifeSafety.VerySafe,
                    ShortDescription = "The Hottest City On Earth",
                    Description = "Barcelona is cradled in the North Eastern Mediterranean coast of mainland Spain, about 2 hours drive South from the French Pyrenees. It's the capital of Catalunya, a region of Northern Spain that has its own unique culture, traditions and personality.",
                    CountryID = 3,
                    CitySpeciality = CitySpeciality.Modern,
                    DailyExpence = 100
                },
                // 6
                new City {
                    CityName = "London",
                    ImageSrc = "https://www.homeaway.co.uk/files/live/sites/hr/files/shared/new%20hips/short-term-rentals/Short_Term_Rentals_London.jpg",
                    Safety = LifeSafety.Safe,
                    ShortDescription = "City Of the Queen",
                    Description = "London is the capital city of England and the United Kingdom, and the largest city, urban zone and metropolitan area in United Kingdom, and the European Union by the most measures. Located on the River Thames, London has been a major settlement for two millennia, its history going back to its founding by the Romans, who named it Londinium.",
                    CountryID = 4,
                    CitySpeciality = CitySpeciality.History,
                    DailyExpence = 400

                },
                // 7
                new City {
                    CityName = "New York",
                    ImageSrc = "http://odysseytreks.com/wp-content/uploads/2013/10/new%20york%20times%20square.jpg",
                    ShortDescription = "The City That Never Sleeps",
                    Description = "Situated on one of the world's largest natural harbors, New York City consists of five boroughs, each of which is a separate county of New York State. The five boroughs – Brooklyn, Queens, Manhattan, The Bronx, and Staten Island – were consolidated into a single city in 1898.",
                    CountryID = 6,
                    Safety = LifeSafety.Safe,
                    CitySpeciality = CitySpeciality.Modern,
                    DailyExpence = 300
                },
                // 8
                new City {
                    CityName = "Bombay",
                    ImageSrc = "http://www.winmaxitravels.com/images/top%20destination/taj_mahal1.jpg",
                    Safety = LifeSafety.Dangerous,
                    ShortDescription = "The Diamond Of The Crown",
                    Description = "Bombay, or Mumbai as it is now called, is the commercial capital of India, a city of entrepreneurs, concrete towers, clubs and discos, cricket, Bollywood and more. The city, a cluster of seven islands, was named by its natives after the goddess Mumbadevi.",
                    CountryID = 7,
                    CitySpeciality = CitySpeciality.History,
                    DailyExpence = 40
                },
                // 9
                new City {
                    CityName = "Paris",
                    ImageSrc = "http://www.schuch.travel/fileadmin/reisedatenbank/_processed_/csm_Paris_d88773392e.jpg",
                    Safety = LifeSafety.ExtremelyDangerous,
                    ShortDescription = "The Ultimate City For Honey Moon",
                    Description = "Paris can be seen as thé most interesting city of Europe and probably even as one of the most amazing city’s worldwide. People from all over the world travel to Paris to discover and experience this fairy-like city. Paris is the city of love, inspiration, art and fashion.",
                    CountryID = 5,
                    CitySpeciality = CitySpeciality.Romantic,
                    DailyExpence = 700
                },


           };


                foreach (var s in cities)
                {
                    context.Cities.Add(s);
                }
                context.SaveChanges();
            }

            #endregion

            // ----------------------------------------------------
            // Initializng the locations of the attractions
            // ----------------------------------------------------

            #region Locations

            if (!context.Locations.Any())
            {
                var locations = new Location[]
                {
                    // Location id = 1, (Rome, Botanical Garden)
                    new Location
                    {
                        X = 41.7850304,
                        Y = 13.0259744
                    },
                    // Location id = 2, (Rome, Piazza del Popolo)
                    new Location
                    {
                        X = 41.9107038,
                        Y = 12.4785466
                    },
                    // Location id = 3, (Florence Cathedral)
                    new Location
                    {
                        X = 43.773145,
                        Y = 11.2581489
                    },
                    // Location id = 4, (Florence, Piazza della Repubblica)
                    new Location
                    {
                        X = 41.9027413,
                        Y = 12.4974196
                    },
                    // Location id = 5, ()
                    new Location
                    {
                        X = 45.4406791,
                        Y = 12.3388717
                    },
                    // Location id = 6, (Venice Film Festival)
                    new Location
                    {
                        X = 45.4046846,
                        Y = 12.3690179
                    },
                    // Location id = 7, (Pinacoteca di Brera)
                    new Location
                    {
                        X = 45.4719545,
                        Y = 9.1900032
                    },
                    // Location id = 8, (Sforza Castle)
                    new Location
                    {
                        X = 45.4704762,
                        Y = 9.1815212
                    }, 
                    // Location id = 9, (Sagrada Família)
                    new Location
                    {
                        X = 41.4036299,
                        Y = 2.1765445
                    },
                    // Location id = 10, (national Art Museum of Catalonia)
                    new Location
                    {
                        X = 41.3684399,
                        Y = 2.1557587
                    },
                    // Location id = 11, (2 Willow Road)
                    new Location
                    {
                        X = 51.5571457,
                        Y = -0.1670234
                    },
                    // Location id = 12, (Big ben)
                    new Location
                    {
                        X = 51.5007292,
                        Y = -0.1224367
                    },
                    // Location id = 13, (Statue of Liberty)
                    new Location
                    {
                        X = 40.6892494,
                        Y = -74.0423117
                    },
                    // Location id = 14, (Brooklyn Bridge)
                    new Location
                    {
                        X = 40.7060855,
                        Y = -73.9946756
                    },
                    // Location id = 15, (Unisphere)
                    new Location
                    {
                        X = 40.7463844,
                        Y = -73.8428732
                    },
                    // Location id = 16, (Chhatrapati Shivaji Terminus railway station)
                    new Location
                    {
                        X = 18.9398208,
                        Y = 72.8376563
                    },
                    // Location id = 17, (Gateway of India)
                    new Location
                    {
                        X = 18.9219841,
                        Y = 72.836843
                    },
                    // Location id = 18, (Paris, Île de la Cité)
                    new Location
                    {
                        X = 48.8547031,
                        Y = 2.3503671
                    },
                    // Location id = 19, (Paris, Eiffel Tower)
                    new Location
                    {
                        X = 48.8583701,
                        Y = 2.29667
                    },
              };

                foreach (var l in locations)
                {
                    context.Locations.Add(l);
                }
                context.SaveChanges();

            }

            #endregion

            //// ----------------------------------------------------
            //// Initializing attractions
            //// ----------------------------------------------------
            #region Attractions


            if (!context.Attractions.Any())
            {
                var attractions = new Attraction[]
                {
                    // attraction id = 1 
                    new Attraction
                    {
                        CityID = 1, // Rome
                        AttractionName = "Botanical Garden",
                        Cost = 7,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.View,
                        Score = 4.0,
                        LocationID = 1,
                        Description = "The Botanical Garden of Rome is one of the Museums of the Department of Environmental Biology of the Sapienza University of Rome. It covers an area of about 30 acres in the very heart of the city, between Via della Lungara and Colle del Gianicolo, occupying part of the archaeological area called Horti Getae, which in ancient times contained the thermal baths of Septimius Severus. Since 1883, the Botanical Garden of Rome has been situated next to Palazzo Riario-Corsini, with whom it shares a historic garden layout. The area contains numerous specimens of palm trees in the main path.",
                        ImageSrc = "http://www.livesalerno.com/images/sightseeing/parks/villacomunale/villacomunale2.jpg"

                    },
                    // attraction id = 2 
                    new Attraction
                    {
                        CityID = 1, // Rome
                        AttractionName = "Piazza del Popolo",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.4,
                        LocationID = 2,
                        Description = "Piazza del Popolo is a large urban square in Rome. The name in modern Italian literally means \"People's Square\", but historically it derives from the poplars (populus in Latin, pioppo in Italian) after which the church of Santa Maria del Popolo, in the northeast corner of the piazza, takes its name. The piazza lies inside the northern gate in the Aurelian Walls, once the Porta Flaminia of ancient Rome, and now called the Porta del Popolo. This was the starting point of the Via Flaminia, the road to Ariminum (modern-day Rimini) and the most important route to the north. At the same time, before the age of railroads, it was the traveller\'s first view of Rome upon arrival. For centuries, the Piazza del Popolo was a place for public executions, the last of which took place in 1826.",
                        ImageSrc = "http://innovation.cityminded.org/wp-content/uploads/2014/03/Piazza-in-Rome.jpg"
                    },
                    // attraction id = 3 
                    new Attraction
                    {
                        CityID = 2, // Florence
                        AttractionName = "Florence Cathedral",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.7,
                        LocationID = 3,
                        Description = "The Cattedrale di Santa Maria del Fiore is the main church of Florence, Italy. Il Duomo di Firenze, as it is ordinarily called, was begun in 1296 in the Gothic style with the design of Arnolfo di Cambio and completed structurally in 1436 with the dome engineered by Filippo Brunelleschi.[1] The exterior of the basilica is faced with polychrome marble panels in various shades of green and pink bordered by white and has an elaborate 19th-century Gothic Revival façade by Emilio De Fabris. The cathedral complex, located in Piazza del Duomo, includes the Baptistery and Giotto's Campanile. These three buildings are part of the UNESCO World Heritage Site covering the historic centre of Florence and are a major attraction to tourists visiting Tuscany. The basilica is one of Italy's largest churches, and until development of new structural materials in the modern era, the dome was the largest in the world. It remains the largest brick dome ever constructed. The cathedral is the mother church of the Roman Catholic Archdiocese of Florence, whose archbishop is currently Giuseppe Betori.",
                        ImageSrc = "http://www.civitavecchiacabservice.com/wp-content/uploads/2016/01/firenze2-1.jpg"
                    },
                     // attraction id = 4
                    new Attraction
                    {
                        CityID = 2, // Florence
                        AttractionName = "Piazza della Repubblica",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.View,
                        Score = 0,
                        LocationID = 4,
                        Description = "Piazza della Repubblica is a city square in Florence, Italy. It is on the site, first of the city's forum and then of the city's old ghetto, which was swept away during the city improvement works or Risanamento initiated during the brief period when Florence was the capital of a reunited Italy, work that also created the city's avenues and boulevards. The ghetto has disappeared from the square, and the Loggia del Pesce from the Mercato Vecchio was moved to Piazza Ciompi. Among the square's cafes, the Giubbe Rosse cafe has long been a meeting place for famous artists and writers, notably those of Futurism.",
                        ImageSrc = "https://www.homeaway.co.uk/files/live/sites/hr/files/shared/new%20hips/special%20occasions/collections/rome_republicday.jpg"
                    },
                    // attraction id = 5
                    new Attraction
                    {
                        CityID = 3, // Venice 
                        AttractionName = "Carnival of Venice",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.View,
                        Score = 4.7,
                        LocationID = 5,
                        Description = "The Carnival of Venice  is an annual festival held in Venice, Italy. The Carnival ends with the Christian celebration of Lent, forty days before Easter, on Shrove Tuesday (Martedì Grasso or Mardi Gras), the day before Ash Wednesday. The festival is world famous for its elaborate masks.",
                        ImageSrc = "https://www.ncl.com/sites/default/files/PortGalleries.Venice.Carnival.jpg"
                    },
                    // attraction id = 6
                    new Attraction
                    {
                        CityID = 3, // Venice 
                        AttractionName = "Venice Film Festival",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 0,
                        LocationID = 6,
                        Description = "The Venice Film Festival or Venice International Film Festival, founded in 1932, is the oldest film festival in the world and one of the \"Big Three\" film festivals alongside the Cannes Film Festival and Berlin International Film Festival. The film festival is part of the Venice Biennale, which was founded by the Venetian City Council in 1895. Today, the Biennale includes a range of separate events including: the International Art Exhibition; the International Festival of Contemporary Music; the International Theatre Festival; the International Architecture Exhibition; the International Festival of Contemporary Dance; the International Kids' Carnival; and the annual Venice Film Festival, which is arguably the best-known of all the events. The film festival has since taken place in late August or early September on the island of the Lido, Venice, Italy.Screenings take place in the historic Palazzo del Cinema on the Lungomare Marconi and in other venues nearby.Since its inception the Venice Film Festival has grown into one of the most prestigious film festivals in the world. The 74th Venice International Film Festival is scheduled to be held from 30 August to 9 September 2017.",
                        ImageSrc = "http://ajff.org/sites/default/files/hero_History_01.jpg"
                    },
                    // attraction id = 7
                    new Attraction
                    {
                        CityID = 4, // milan
                        AttractionName = "Pinacoteca di Brera",
                        Cost = 20,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.View,
                        Score = 3.7,
                        LocationID = 7,
                        Description = "The Pinacoteca di Brera (\"Brera Art Gallery\") is the main public gallery for paintings in Milan, Italy. It contains one of the foremost collections of Italian paintings, an outgrowth of the cultural program of the Brera Academy, which shares the site in the Palazzo Brera.",
                        ImageSrc = "https://martebenicult.files.wordpress.com/2015/07/pinacoteca-brera-milano.jpg?w=900&h=400&crop=1"
                    },
                    // attraction id = 8
                    new Attraction
                    {
                        CityID = 4, // milan
                        AttractionName = "Sforza Castle",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.View,
                        Score = 0,
                        LocationID = 8,
                        Description = "Sforza Castle is a castle in Milan, northern Italy. It was built in the 15th century by Francesco Sforza, Duke of Milan, on the remains of a 14th-century fortification. Later renovated and enlarged, in the 16th and 17th centuries it was one of the largest citadels in Europe. Extensively rebuilt by Luca Beltrami in 1891–1905, it now houses several of the city's museums and art collections.",
                        ImageSrc = "http://passionread.com/wp-content/uploads/2015/10/10-most-visited-countries-in-the-world14.jpg"
                    },
                    // attraction id = 9 
                    new Attraction
                    {
                        CityID = 5, // Barcelona
                        AttractionName = "Basilica and Expiatory Church of the Holy Family",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.7,
                        LocationID = 9,
                        Description = "The Basílica i Temple Expiatori de la Sagrada Família is a large Roman Catholic church in Barcelona, designed by Catalan Spanish architect Antoni Gaudí (1852–1926). Although incomplete, the church is a UNESCO World Heritage Site, and in November 2010 Pope Benedict XVI consecrated and proclaimed it a minor basilica, as distinct from a cathedral, which must be the seat of a bishop. Construction of Sagrada Família commenced in 1882 by architect Francisco Paula de Villar with Gaudí becoming involved in 1883 after Francisco resigned as the head architect. Taking over the project, Gaudí transformed it with his architectural and engineering style, combining Gothic and curvilinear Art Nouveau forms. Gaudí devoted his last years to the project, and at the time of his death at age 73 in 1926, less than a quarter of the project was complete.",
                        ImageSrc = "https://static.dezeen.com/uploads/2015/10/Sagrada-Familia_Antoni-Gaudi_dezeen_936_0.jpg"
                    },
                    // attraction id = 10 
                    new Attraction
                    {
                        CityID = 5, // Barcelona
                        AttractionName = "National Art Museum of Catalonia",
                        Cost = 10,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Museum,
                        Score = 4.5,
                        LocationID = 10,
                        Description = "The Museu Nacional d'Art de Catalunya, abbreviated as MNAC, is the national museum of Catalan visual art located in Barcelona, Catalonia, Spain. Situated on Montjuïc hill at the end of Avinguda de la Reina Maria Cristina, near Pl Espanya, the museum is especially notable for its outstanding collection of romanesque church paintings, and for Catalan art and design from the late 19th and early 20th centuries, including modernisme and noucentisme. The Museum is housed in the Palau Nacional, a huge, Italian-style building dating to 1929. The Palau Nacional, which has housed the Museu d'Art de Catalunya since 1934, was declared a national museum in 1990 under the Museums Law passed by the Catalan Government. That same year, a thorough renovation process was launched to refurbish the site, based on plans drawn up by the architects Gae Aulenti and Enric Steegmann, who were later joined in the undertaking by Josep Benedito. The Oval Hall was reopened in 1992 on the occasion of the Olympic Games, and the various collections were installed and opened over the period from 1995 (when the Romanesque Art section was reopened) to 2004. The Museu Nacional d'Art de Catalunya (Museu Nacional) was officially inaugurated on 16 December 2004. It is one of the largest museums in Spain.",
                        ImageSrc = "http://ob9a8415roh4djoj110c31a1.wpengine.netdna-cdn.com/wp-content/uploads/2014/02/Barcelona-MNAC.jpg"
                    },
                    // attraction id = 11 
                    new Attraction
                    {
                        CityID = 6, // London
                        AttractionName = "2 Willow Road",
                        Cost = 20,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.5,
                        LocationID = 11,
                        Description = "2 Willow Road is part of a terrace of three houses in Hampstead, London designed by architect Ernő Goldfinger and completed in 1939. It has been managed by the National Trust since 1995 and is open to the public. It was one of the first Modernist buildings acquired by the Trust, giving rise to some controversy. Goldfinger lived there with his wife Ursula and their children until his death in 1987. 1–3 Willow Road was constructed using concrete and a facing of red brick.A number of cottages were demolished to allow for the construction, which was strongly opposed by a number of local residents including novelist Ian Fleming(this was said to be his inspiration for the name of the James Bond villain Auric Goldfinger) and the future Conservative Home Secretary Henry Brooke. No. 2, which Goldfinger designed specifically as his own family home, is the largest of the three houses and features a spiral staircase designed by Danish engineer Ove Arup at its core.The building is supported by a concrete frame, part of which is external, leaving room for a spacious uncluttered interior, perhaps inspired by the Raumplan ideas of modernist architect Adolf Loos. Goldfinger himself designed much of the furniture in No. 2, and the house also contains a significant collection of 20th - century art by Bridget Riley, Marcel Duchamp, Henry Moore and Max Ernst. Entry is by timed ticket, and facilities are very limited.Nos. 1 and 3 remain private homes.",
                        ImageSrc = "https://upload.wikimedia.org/wikipedia/commons/5/5e/1-3_Willow_Road.jpg"
                    },
                    // attraction id = 12 
                    new Attraction
                    {
                        CityID = 6, // London
                        AttractionName = "Big Ben",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.7,
                        LocationID = 12,
                        Description = "Big Ben is the nickname for the Great Bell of the clock at the north end of the Palace of Westminster in London, and often extended to refer to the clock and the clock tower. The tower is officially known as Elizabeth Tower, renamed to celebrate the Diamond Jubilee of Elizabeth II in 2012; previously it was known simply as the Clock Tower. The tower holds the second largest four-faced chiming clock in the world (after Minneapolis City Hall). The tower was completed in 1859 and had its 150th anniversary on 31 May 2009, during which celebratory events took place. The tower has become one of the most prominent symbols of the United Kingdom and is often in the establishing shot of films set in London.",
                        ImageSrc = "https://mi-od-live-s.legocdn.com/r/www/r/architecture/-/media/franchises/architecture%202015/explore/available%20products/story/21013%20big%20ben/21013_facts_explore_720.jpg?l.r2=1029380932"
                    },
                    // attraction id = 13 
                    new Attraction
                    {
                        CityID = 7, // New York
                        AttractionName = "Statue of Liberty",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.5,
                        LocationID = 13,
                        Description = "The Statue of Liberty is a colossal neoclassical sculpture on Liberty Island in New York Harbor in New York City, in the United States. The copper statue, designed by Frédéric Auguste Bartholdi, a French sculptor, was built by Gustave Eiffel and dedicated on October 28, 1886. It was a gift to the United States from the people of France. The statue is of a robed female figure representing Libertas, the Roman goddess, who bears a torch and a tabula ansata (a tablet evoking the law) upon which is inscribed the date of the American Declaration of Independence, July 4, 1776. A broken chain lies at her feet. The statue is an icon of freedom and of the United States, and was a welcoming sight to immigrants arriving from abroad. Bartholdi was inspired by French law professor and politician Édouard René de Laboulaye, who is said to have commented in 1865 that any monument raised to American independence would properly be a joint project of the French and American peoples. He may have been minded to honor the Union victory in the American Civil War and the end of slavery. Due to the post-war instability in France, work on the statue did not commence until the early 1870s. In 1875, Laboulaye proposed that the French finance the statue and the Americans provide the site and build the pedestal. Bartholdi completed the head and the torch-bearing arm before the statue was fully designed, and these pieces were exhibited for publicity at international expositions.",
                        ImageSrc = "https://upload.wikimedia.org/wikipedia/commons/b/b2/Statue_of_Liberty_-_4621961395.jpg"
                    },
                    // attraction id = 14 
                    new Attraction
                    {
                        CityID = 7, // New York
                        AttractionName = "Brooklyn Bridge",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.6,
                        LocationID = 14,
                        Description = "The Brooklyn Bridge is a hybrid cable-stayed/suspension bridge in New York City and is one of the oldest bridges of either type in the United States  Completed in 1883, it connects the boroughs of Manhattan and Brooklyn by spanning the East River  It has a main span of 1,595 5 feet (486 3 m) and was the first steel-wire suspension bridge constructed  It was originally referred to as the New York and Brooklyn Bridge and as the East River Bridge, but it was later dubbed the Brooklyn Bridge, a name coming from an earlier January 25, 1867, letter to the editor of the Brooklyn Daily Eagle and formally so named by the city government in 1915  Since its opening, it has become an icon of New York City and was designated a National Historic Landmark in 1964 and a National Historic Civil Engineering Landmark in 1972.",
                        ImageSrc = "http://c4.nrostatic.com/sites/default/files/styles/original_image_with_cropping/public/uploaded/pic_giant_052915_SM_Brooklyn-Bridge-DT.jpg?itok=-MTToI9Z"
                    },
                    // attraction id = 15 
                    new Attraction
                    {
                        CityID = 7, // New York
                        AttractionName = "Unisphere",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 3,
                        LocationID = 15,
                        Description = "The Unisphere is a 120 ft (37 m), spherical stainless steel representation of the Earth. Located in Flushing Meadows–Corona Park in the borough of Queens, New York City, the Unisphere is one of the borough's most iconic and enduring symbols. Commissioned to celebrate the beginning of the space age, the Unisphere was conceived and constructed as the theme symbol of the 1964–1965 New York World's Fair. The theme of the World's Fair was \"Peace Through Understanding\" and the Unisphere represented the theme of global interdependence. It was dedicated to \"Man's Achievements on a Shrinking Globe in an Expanding Universe\".",
                        ImageSrc = "http://todaysthedayi.com/wp-content/uploads/2015/06/P1100449.jpg"
                    },
                    // attraction id =  16
                    new Attraction
                    {
                        CityID = 8, // Bombay
                        AttractionName = "Chhatrapati Shivaji Terminus railway station",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.4,
                        LocationID = 16,
                        Description = "Chhatrapati Shivaji Terminus (CST), is an historic railway station and a UNESCO World Heritage Site in Mumbai, Maharashtra, India which serves as the headquarters of the Central Railways. Designed by Frederick William Stevens with influences from Victorian Italianate Gothic Revival architecture and traditional Mughal buildings, the station was built in 1887 in the Bori Bunder area of Mumbai to commemorate the Golden Jubilee of Queen Victoria. The new railway station was built on the location of the Bori Bunder railway station and is one of the busiest railway stations in India, serving as a terminal for both long-distance trains and commuter trains of the Mumbai Suburban Railway. The station's name was changed to its present one in March 1996 and it is now known simply as CST (or CSTM). Total 154 passenger trains Start/End/PassThrough Chhatrapati Shivaji Terminus. Total 591 Stations are directly connected to Chhatrapati Shivaji Terminus via these 269 passenger trains.",
                        ImageSrc = "http://travel2cities.weebly.com/uploads/1/4/2/0/14206994/573553180_orig.jpg?646"
                    },
                    // attraction id = 17
                    new Attraction
                    {
                        CityID = 8, // Bombay
                        AttractionName = "Gateway of India",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.5,
                        LocationID = 17,
                        Description = "The Gateway of India is a monument built during the 20th century in Mumbai City of Maharashtra state in Western India. It is located on the waterfront in the Apollo Bunder area in South Mumbai and overlooks the Arabian Sea. The structure is a basalt arch, 26 metres (85 feet) high. It lies at the end of Chhatrapati Shivaji Marg at the water's edge in Mumbai Harbour. It was a crude jetty used by the fishing community which was later renovated and used as a landing place for British governors and other prominent people. In earlier times, it would have been the first structure that visitors arriving by boat in Mumbai would have seen. The Gateway has also been referred to as the Taj Mahal of Mumbai, and is the city's top tourist attraction. The structure was erected to commemorate the landing of King George V and Queen Mary at Apollo Bunder, when they visited India in 1911. Built in Indo-Saracenic style, the foundation stone for the Gateway of India was laid on 31 March 1911. The final design of George Wittet was sanctioned in 1914 and the construction of the monument was completed in 1924. The Gateway was later the ceremonial entrance to India for Viceroys and the new Governors of Bombay. It served to allow entry and access to India. The monument has witnessed three terror attacks since the beginning of the 21st century; twice in 2003 and it was also the disembarkation point in 2008 when four gunmen attacked the Taj Mahal Palace &Tower.",
                        ImageSrc = "http://2.bp.blogspot.com/-frkjLhuQ544/VhqkXzKrR1I/AAAAAAAAJ5c/uDchGkK-ONI/s1600/Gateway-of-India-south-india-tourism.jpg"
                    },
                    // attraction id =  18
                    new Attraction
                    {
                        CityID = 9, // Paris
                        AttractionName = "Île de la Cité",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.View,
                        Score = 4.3,
                        LocationID = 18,
                        Description = "The Île de la Cité  is one of two remaining natural islands in the Seine within the city of Paris (the other being the Île Saint-Louis).[a] It is the centre of Paris and the location where the medieval city was refounded. The western end has held a palace since Merovingian times, and its eastern end since the same period has been consecrated to religion, especially after the 10th century construction of a cathedral preceding today's Notre Dame. The land between the two was, until the 1850s, largely residential and commercial, but has since been filled by the city's Prefecture de Police, Palais de Justice, Hôtel-Dieu hospital and Tribunal de commerce. Only the westernmost and northeastern extremities of the island remain residential today, and the latter preserves some vestiges of its 16th-century canon/'s houses. The Mémorial des Martyrs de la Déportation, a memorial to the 200,000 people deported from Vichy France to the Nazi concentration camps during the Second World War, is located at the upriver end of the island.",
                        ImageSrc = "https://upload.wikimedia.org/wikipedia/commons/e/eb/%C3%8Ele_de_la_Cit%C3%A9_shortly_before_sunrise,_West_View_140320_1.jpg"
                    },
                    // attraction id = 19
                    new Attraction
                    {
                        CityID = 9, // Paris
                        AttractionName = "Eiffel Tower",
                        Cost = 0,
                        DesignatedAge = DesignatedAge.Family,
                        Type = AttractionType.Architecture,
                        Score = 4.7,
                        LocationID = 19,
                        Description = "The Eiffel Tower is a wrought iron lattice tower on the Champ de Mars in Paris, France. It is named after the engineer Gustave Eiffel, whose company designed and built the tower. Constructed from 1887-89 as the entrance to the 1889 World's Fair, it was initially criticized by some of France's leading artists and intellectuals for its design, but it has become a global cultural icon of France and one of the most recognisable structures in the world. The Eiffel Tower is the most - visited paid monument in the world; 6.91 million people ascended it in 2015.  The tower is 324 metres(1, 063 ft) tall, about the same height as an 81 - storey building, and the tallest structure in Paris.Its base is square, measuring 125 metres(410 ft) on each side.During its construction, the Eiffel Tower surpassed the Washington Monument to become the tallest man-made structure in the world, a title it held for 41 years until the Chrysler Building in New York City was finished in 1930.Due to the addition of a broadcasting aerial at the top of the tower in 1957, it is now taller than the Chrysler Building by 5.2 metres(17 ft).Excluding transmitters, the Eiffel Tower is the second - tallest structure in France after the Millau Viaduct.  The tower has three levels for visitors, with restaurants on the first and second levels.The top level's upper platform is 276 m (906 ft) above the ground – the highest observation deck accessible to the public in the European Union. Tickets can be purchased to ascend by stairs or lift (elevator) to the first and second levels. The climb from ground level to the first level is over 300 steps, as is the climb from the first level to the second. Although there is a staircase to the top level, it is usually only accessible by lift.",
                        ImageSrc = "http://cdn.history.com/sites/2/2015/04/hith-eiffel-tower-iStock_000016468972Large.jpg"
                    }                  
              };

                foreach (var a in attractions)
                {
                    context.Attractions.Add(a);
                }
                context.SaveChanges();

            }
            #endregion
        }

        public static async void InitializeUser(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService(typeof(ApplicationDbContext));


            try
            {
                if (!((ApplicationDbContext)context).Users.Any())
                {

                    ApplicationUser objUser = new ApplicationUser()
                    {
                        UserName = "hizki",
                        Email = "omer.haimovich@gmail.com",
                        TwoFactorEnabled = false,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "5a27cc4c-70ab-4f88-884d-bbd5963358d8",
                        PhoneNumberConfirmed = true,
                        PhoneNumber = "+972526727163",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        LockoutEnd = null,
                        NormalizedUserName = "HIZKI",
                        SecurityStamp = "0b645337-2092-4989-a29c-87c8021c8f01",
                        NormalizedEmail = "OMER.HAIMOVICH@GMAIL.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAEChTGlCukhiIxHXAMGvO3+n77CVflJ8pieOPL6hizHX8xNpBTiZ4ISnLWgnszLNFWQ=="
                    };

                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(objUser, "Aa123456!@#$%^");
                    objUser.PasswordHash = hashed;

                    var userStore = new UserStore<ApplicationUser>(((ApplicationDbContext)context));
                    var result = await userStore.CreateAsync(objUser);
                }
            }
            catch (Exception e)
            {

            }

        }

    }
}

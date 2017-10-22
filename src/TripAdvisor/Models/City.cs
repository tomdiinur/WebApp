using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripAdvisor.Models
{

    public enum CitySpeciality
    {
        Architecture,
        View,
        Modern,
        History,
        Romantic

    }

    public enum LifeSafety
    {
        ExtremelyDangerous,
        Dangerous,
        Safe,
        VerySafe,        
    }

    public class City
    {
        [Key]
        public int ID { get; set; }

        
        [Required]
        public int CountryID { get; set; }

        [Required]
        public string CityName { get; set; }
        
        [Required]
        public string ImageSrc { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public CitySpeciality CitySpeciality { get; set; }

        [Required]
        public int DailyExpence { get; set; }

        [Required]
        public LifeSafety Safety { get; set; }

        [ForeignKey("CountryID")]        
        public virtual Country Country { get; set; }

        public virtual ICollection<Attraction> Attractions { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripAdvisor.Models
{
    public enum DesignatedAge
    {
        Children,
        Teenagers,
        Couples,        
        Family
    }

    public enum AttractionType
    {
        Architecture,
        Museum,
        Restaurant,        
        View,
    }

    public class Attraction
    {        
        [Key]
        public int ID { get; set; }
        [Required]
        public int CityID { get; set; }
        [Required]
        public string AttractionName { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public DesignatedAge DesignatedAge { get; set; }
        [Required]
        public AttractionType Type { get; set; }
        [Required]
        public double Score { get; set; }
        [Required]
        public int LocationID { get; set; }        
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageSrc { get; set; }
    }
}

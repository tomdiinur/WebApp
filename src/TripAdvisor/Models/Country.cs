using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripAdvisor.Models
{
    public enum Continent
    {
        Asia,
        Africa,
        Europe,
        Australia,
        America
    }

    public enum CommonReligion
    {
        Judaism,
        Christianity,
        Islam,
        Hindi
    }

    public enum JewsAttitude
    {
        Pro,
        Neuteral,
        Against
    }


    public class Country : IEquatable<Country>
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public Continent Continent { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ShortDesription { get; set; }

        [Required]
        public string ImageSrc { get; set; }

        [Required]
        public CommonReligion CommonReligion { get; set; }

        [Required]
        public JewsAttitude AttitudeForJews { get; set; }

        [Required]
        public virtual ICollection<City> Cities { get; set; }

        public bool Equals(Country other)
        {
            if (this.ID == other.ID)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }

        public override bool Equals(object obj)
        {
            return obj is Country && (obj as Country).ID == this.ID;
        }
        
    }
}

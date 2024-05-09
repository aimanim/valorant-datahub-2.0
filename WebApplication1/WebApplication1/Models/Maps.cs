using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Maps
    {
        [Key]
        public string Map_Name { get; set; }
        [Required]
        public int Spike_sites { get; set; }
        [Required]
        [ForeignKey("weapons")]
        public string Suited_Weapon { get; set; }
        public virtual Weaponary weapons { get; set; }
        [Required]
        [ForeignKey("Locations")]
        public int Location_id { get; set; }
        public virtual Location Locations { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public string location { get; set; }
        [NotMapped]
        public User user;

    }
}

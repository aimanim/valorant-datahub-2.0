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
        public string Suited_Weapon { get; set; }
        [Required]
        public int Location_id { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public string location { get; set; }
        [NotMapped]
        public User user;

    }
}

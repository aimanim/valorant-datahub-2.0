using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Player
    {
        [Key]
        public int Pid { get; set; }
        [Required]
        public string Pname { get; set; }

        [Required]
        [ForeignKey("Locations")]
        public int Location_id { get; set; }
        public virtual Location Locations { get; set; }
        
        [ForeignKey("Agents")]
        public string Fav_agent { get; set; }
        public virtual agents Agents { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        [Required]
        public int MMR { get; set; }
        [Required]
        public int Kills { get; set; }
        [Required]
        public int Deaths { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Player
    {
        [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int Location_id { get; set; }
        public string Fav_agent { get; set; }
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

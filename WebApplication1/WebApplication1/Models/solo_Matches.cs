using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class solo_Matches
    {
        [Key]
        public int Match_ID { get; set; }
        
        public int Kills { get; set; }
        
        public int Deaths { get; set; }

        public string Result { get; set; }
        [Required]
        public string Agent_Played { get; set; }
        [Required]
        public string Map_Name { get; set; }
        [Required]
        public int Player_ID { get; set; }
    }
}

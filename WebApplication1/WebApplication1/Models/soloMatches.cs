using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class soloMatches
    {
        [Key]
        public int Match_ID { get; set; }
        
        public int Kills { get; set; }
        
        public int Deaths { get; set; }

        public string Result { get; set; }
        [Required]
        [ForeignKey("Agents")]
        public string Agent_Played { get; set; }
        public virtual agents Agents { get; set; }
        [Required]
        [ForeignKey("maps")]
        public string Map_Name { get; set; }
        public virtual Maps maps { get; set; }
        [Required]
        [ForeignKey("Players")]
        public int Pid { get; set; }
        public virtual Player Players { get; set; }
    }
}

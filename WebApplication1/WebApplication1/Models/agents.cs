using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class agents
    {
        [Key]
        public string agent_name { get; set; }
        [Required]
        public float pick_pct { get; set; }
        [Required]
        public float win_pct { get; set; }
        [Required]
        public string tier { get; set; }
        [Required]
        public string role { get; set; }

        [ForeignKey("Weapon")] 
        public string? suited_weapon { get; set; }  
        public virtual Weapons Weapon { get; set; }
        [Required]
        public string ultimate { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string voiced_by { get; set; }
    }
}

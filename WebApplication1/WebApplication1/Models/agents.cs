using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class agents
    {
        [Key]
        public string agent_name { get; set; }

        public float pick_pct { get; set; }
        public float win_pct { get; set; }
        public string tier { get; set; }
        public string role { get; set; }

        [ForeignKey("Weapon")] // Assuming a table named "Weapon" with an "id" column
        public string? suited_weapon { get; set; }  // Nullable string

        public string ultimate { get; set; }
        public string description { get; set; }
        public string voiced_by { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
    public class Weapons
    {
        [Key]
        public string Weapon_Name { get; set; }
        public string? Weapon_Type { get; set; }
        public int? Capacity { get; set; }
        public float? Damage { get; set; }
        public float? Fire_Rate { get; set; }
        public float? Reload_Speed { get; set; }
        public string? Fire_Mode { get; set; }
        public int? Max_Range { get; set; }
    }
}

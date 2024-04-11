using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Location
    {
        [Key]
        public int Location_id { get; set; }
        [Required]
        public string Country { get; set; }
        public string? City { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Matches
    {
        [Key]
        public int Match_id { get; set; }
        public int Team1_id { get; set; }
        public int Team2_id { get; set;}
        public int Winner_id { get; set; }
        public string Map_Name { get; set; }
    }
}

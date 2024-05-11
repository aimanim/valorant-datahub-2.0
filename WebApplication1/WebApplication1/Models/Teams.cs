using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Teams
    {
        [Key]
        public int Team_id { get; set; }
        public string Team_Name { get; set; }
        public int Matches_Won { get; set; }
        public int Matches_Played { get; set; }
        public int Tournaments_Won { get; set; }
        public int Tournaments_Played { get; set; }
    }
}

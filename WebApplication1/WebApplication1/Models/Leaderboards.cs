using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Leaderboards
    {
        public string username { get; set; } // Assuming username is unique

        public string Pname { get; set; }
        public string fav_agent { get; set; }

        public decimal KD_Ratio { get; set; } // Assuming KD Ratio is a currency value

        public string country { get; set; }
        public int MMR { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        [Key]
        public virtual string ShadowKey { get; private set; }
    }
}

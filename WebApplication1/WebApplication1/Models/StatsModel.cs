namespace WebApplication1.Models
{
    public class StatsModel
    {
        public User user { get; set; }
        public Player player {  get; set; }
        public Location location { get; set; }
        public string rank { get; set; }
        public double kd { get; set; }
        public double win_percentage { get; set; }
        public int Wins { get; set; }
        public int Total_Matches { get; set; }
        public string fav_agent_role { get; set; }

        public Dictionary<string, Tuple<int, int>> top_maps { get; set; }
        
        



    }
}

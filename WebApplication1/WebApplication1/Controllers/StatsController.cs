using Azure.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Cryptography;
using WebApplication1.Data;

using WebApplication1.Models;
namespace WebApplication1.Controllers

{
    public class StatsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StatsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string username)
        {
            int PlayerID = 1;
            StatsModel stats = new StatsModel();
            stats.user = new User();
            
            string connection = "Server= BILALS-LAPPY;Database=Valo_Data;Trusted_Connection=True;TrustServerCertificate=True";
            string query = "Select * from users where username = '"+username+"'";
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PlayerID = reader.GetInt32(2);
                                Console.WriteLine(PlayerID);
                                stats.user.player_id = PlayerID;
                            }
                        }
                    }
                    stats.user.Username = username;
                    stats.player = new Player();
                    stats.player = _db.players.FirstOrDefault(p => p.Pid == stats.user.player_id);
                    stats.location = new Location();
                    stats.location = _db.locations.FirstOrDefault(p => p.Location_id == stats.player.Location_id);
                    var fav_agent = _db.Agents.FirstOrDefault(p => p.agent_name == stats.player.Fav_agent);
                    stats.fav_agent_role = fav_agent.role;
                    query = "select dbo.GetRank(@MMR)";

                    stats.kd = Math.Round(((double)stats.player.Kills / stats.player.Deaths), 1);
                    

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@MMR", stats.player.MMR);
                        stats.rank = command.ExecuteScalar().ToString();

                    }
                    query = $"select Player_ID,count(1)," +
                        $"(select count(1) from solo_matches group by Player_ID,result having result = 'Lost' and Player_ID = s1.Player_ID)," +
                        $"(select count(1) from solo_matches group by Player_ID having Player_ID=s1.Player_ID)" +
                        $"from solo_matches s1 group by Player_ID,result having result = 'Won' and Player_ID = {stats.user.player_id}";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                double hehe = (double)reader.GetInt32(1) / reader.GetInt32(3);
                                stats.Total_Matches = reader.GetInt32(3);
                                stats.win_percentage = Math.Round(hehe*100.0, 2);
                                stats.Wins = reader.GetInt32(1);
                                Console.WriteLine(stats.Total_Matches);
                                Console.WriteLine(reader.GetInt32(1));
                                Console.WriteLine(stats.win_percentage);
                            }
                        }
                    }
                    List<string> MapNames = new List<string>();
                    stats.top_maps = new Dictionary<string, Tuple<int, int>>();
                    MapNames.Add("Bind");MapNames.Add("Breeze");MapNames.Add("Lotus");MapNames.Add("Ascent");MapNames.Add("Fracture");
                    MapNames.Add("Haven");MapNames.Add("Icebox");MapNames.Add("Pearl");MapNames.Add("Split");MapNames.Add("Sunset");
                    foreach(string map in MapNames)
                    {
                        stats.top_maps.Add(map, Tuple.Create(0, 0));
                    }
                    query = $"select map_name,count(1)," +
                        $"(select count(1) from solo_matches where map_name = s1.map_name and Player_ID = s1.Player_ID and result = 'Won')," +
                        $"(select count(1) from solo_matches where map_name = s1.map_name and Player_ID = s1.Player_ID and result = 'Lost')" +
                        $"from solo_matches s1 group by map_name,Player_ID having Player_ID={stats.player.Pid};";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine();
                                stats.top_maps[reader.GetString(0)] = Tuple.Create(reader.GetInt32(2),reader.GetInt32(3));
                            }
                        }
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return View(stats);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class SignupController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SignupController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        //ModelState.AddModelError(string.Empty, "Custom error message goes here");

        [HttpPost]
        public IActionResult Verify(RegistrationModel player)
        {
            Dictionary<string,string> ErrorMessages = new Dictionary<string,string>();
            ErrorMessages["Incomplete"] = "Please fill all the fields marked with '*'";
            ErrorMessages["UserExists"] = "This user name is already taken. Please provide another username. You can try appending a digit at the end of your username and then it might work.";
            ErrorMessages["PasswordMismatch"] = "The passwords you have entered don't match. Please use the show icon to reveal your password inorder to help yourself type same passwords";
            ErrorMessages["WeakPassword"] = "The password should be 8 to 10 characters long and must " +
                                "include a digit and a special character. This is to ensure that your account remains safe and secure." +
                                " For your ease,here is a sample format for the password: 'password1@'.";
            Console.WriteLine("First name" + player.FirstName);
            Console.WriteLine("Last name" + player.LastName);
            Console.WriteLine("Username: " + player.Username);
            if (ModelState.IsValid)
            {
                int Age = CalculateAge(player.DateOfBirth);
                if(player.Password != player.RePassword)
                    return BadRequest(ErrorMessages["PasswordMismatch"]);
                string connection = "Server= BILALS-LAPPY;Database=Valo_Data;Trusted_Connection=True;TrustServerCertificate=True";
                string query = "Select * from users where username = '" + player.Username + "'";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    try
                    {
                        int temp = 0, temp2 = 0;
                        bool flag = false;
                        con.Open();
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    return BadRequest(ErrorMessages["UserExists"]);
                                }
                            }
                        }
                        query = $"select location_id from location where city = '{player.City}' and country = '{player.Country}'";
                        Console.WriteLine("Executed checking if user exists");
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            Console.WriteLine("Command created");
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Console.WriteLine("Reader created");
                                if (reader.HasRows == false)
                                {
                                    flag = true;
                                    Console.WriteLine("Gotta add location");
                                }
                                else
                                {
                                    reader.Read();
                                    temp2 = Convert.ToInt32(reader["location_id"]);
                                    Console.WriteLine("No need to add location");
                                }
                                    
                            }
                        }
                        if(flag)
                        {
                            query = "select TOP 1 location_id from location order by location_id desc";
                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine("Anything?!");
                                        temp2 = Convert.ToInt32(reader["location_id"]) + 1;

                                    }
                                }
                            }
                            Console.WriteLine("Retrieved last location id");
                            query = $"insert into location values({temp2},'{player.Country}','{player.City}')";
                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                command.ExecuteNonQuery();
                            }
                            Console.WriteLine("Inserted new location");
                        }
                        query = "select top 1 pid from player join users on(player.pid = users.player_id) order by pid desc";
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while(reader.Read())
                                {
                                    temp = Convert.ToInt32(reader["pid"]) + 1;
                                }
                            }
                        }
                        Console.WriteLine("Gonna assign pid: " + temp);
                        query = $"insert into player values ({temp}, '{player.FirstName + ' ' + player.LastName}', {temp2}, '{player.Fav_agent}'," +
                            $"'{player.Gender}', {Age}, {20}, {0}, {0})";
                        Console.WriteLine("Insertion query: " + query);
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.ExecuteNonQuery();
                        }
                        try
                        {
                            query = $"insert into users values('{player.Username}','{player.Password}',{temp})";
                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                command.ExecuteNonQuery();
                            }
                            return RedirectToAction("Index", player);
                        }
                        catch(Exception ex)
                        {
                            query = "delete from player where pid = " + temp + "";
                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                command.ExecuteNonQuery();
                            }
                            return BadRequest(ErrorMessages["WeakPassword"]);
                        }

                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return RedirectToAction("Index",player);
            }
            Console.WriteLine("Bad data boooo");
            return BadRequest(ErrorMessages["Incomplete"]);
        }
        public int CalculateAge(string dob)
        {
            DateTime dateOfBirth;
            
            Console.WriteLine(dob);
            if (!DateTime.TryParse(dob, out dateOfBirth))
            {
                throw new ArgumentException("Invalid date of birth format");
            }

            TimeSpan ageDifference = DateTime.Now - dateOfBirth;
            int age = (int)(ageDifference.Days / 365.25);

            return age;
        }

    }
}

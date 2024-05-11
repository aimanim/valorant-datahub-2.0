using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
	public class UpdatepasswordController : Controller
	{
		private readonly ApplicationDbContext _db;
        private User user;
        public UpdatepasswordController(ApplicationDbContext db)
		{
			_db = db;
            user = new User();
            user.Username = "Guest Mode";
        }
		public IActionResult Index(string Username = "Guest Mode")
		{
            user.Username = Username;
            return View("Index", user);
        }
		public IActionResult Verify(string oldPassword, string newPassword, string confirmPassword,string Username)
		{ 
			
            Dictionary<string, string> ErrorMessages = new Dictionary<string, string>();
            ErrorMessages["Incomplete"] = "Please fill all the fields marked with '*'";
            ErrorMessages["PasswordMismatch"] = "The passwords you have entered don't match. Please use the show icon to reveal your password inorder to help yourself type same passwords";
            ErrorMessages["WeakPassword"] = "The password should be 8 to 10 characters long and must " +
                                "include a digit and a special character. This is to ensure that your account remains safe and secure." +
                                " For your ease,here is a sample format for the password: 'password1@'.";
			ErrorMessages["OldIncorrect"] = "The old password that you entered is incorrect. Please use the eye icon to enter the same password that you used for signing in. Thankyou";
            if (oldPassword == "" || newPassword == "" || confirmPassword == "")
            {
				return BadRequest(ErrorMessages["Incomplete"]);
            }
            if (newPassword != confirmPassword)
			{
				return BadRequest(ErrorMessages["PasswordMismatch"]);
			}
			User user = _db.users.FirstOrDefault(x => (x.Password == oldPassword && x.Username == Username));
			if (user == null)
			{
				return BadRequest(ErrorMessages["OldIncorrect"]);
			}
			try
			{
				string query = $"update users set password = '{newPassword}' where username = '{Username}'";
                _db.Database.ExecuteSqlRaw(query);
                return Ok("Password updated successfully");

            }
			catch(Exception ex)
			{
				return BadRequest(ErrorMessages["WeakPassword"]);
			}
			
        }
	}
}

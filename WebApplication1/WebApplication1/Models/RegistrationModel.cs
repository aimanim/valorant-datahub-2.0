using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegistrationModel
    {
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        [Required]
        
        public string Username { get; set; }
        [Required]
        
        public string DateOfBirth { get; set; }
        [Required]
        
        public string Country { get; set; }
        [Required]
       
        public string City { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Fav_agent { get; set; }
    }
}

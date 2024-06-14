using System.ComponentModel.DataAnnotations;

namespace ScopeMed.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Email { get; set; }               // Email must be required
        public string? PasswordHash { get; set; }        //Password must be required
        public DateTime Registrations {  get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}

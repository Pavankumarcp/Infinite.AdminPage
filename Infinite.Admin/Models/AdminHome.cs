using System.ComponentModel.DataAnnotations;

namespace Infinite.AdminPage.Models
{
    public class AdminHome:Login
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[Required]
        //public string Email { get; set; }
        //[Required]
        //public string Password { get; set; }
    }
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

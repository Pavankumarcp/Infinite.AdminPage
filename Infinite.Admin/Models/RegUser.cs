using Microsoft.VisualBasic;
using System;

namespace Infinite.AdminPage.Models
{
    public class RegUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPwd { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
    }
}

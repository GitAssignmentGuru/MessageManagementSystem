using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MessageManagementSystem.Models
{
    public class Login
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter the username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; }
    }
}
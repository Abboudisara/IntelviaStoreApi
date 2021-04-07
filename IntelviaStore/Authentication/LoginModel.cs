using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User User Nam is required")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "User Password is required")]
        public string password { get; set; }
    }
}

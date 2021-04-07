using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage="User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Password is required")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class User
    {
        public int ID { get; set; }
         [Required]
        public string UserName { get; set; }
         [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string EncryptedPassword { get; set; }
        public int CreatedBy { get; set; }





    }
}
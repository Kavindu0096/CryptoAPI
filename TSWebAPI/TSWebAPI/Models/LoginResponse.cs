using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class LoginResponse
    {
        public int ID { get; set; }
       
        public string UserName { get; set; }
        
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string EncryptedPassword { get; set; }
        public PostStatus PostStatusObj { get; set; }
    }
}
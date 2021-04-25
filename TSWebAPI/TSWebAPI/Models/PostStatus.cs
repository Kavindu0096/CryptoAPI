using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class PostStatus
    {
        public string UniqueNo { get; set; }
        public int ErrorId { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorClass { get; set; }
    }
}
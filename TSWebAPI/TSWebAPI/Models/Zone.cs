using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class ZoneObj
    {
        public int ID { get; set; }
        public string Zone { get; set; }
        public int ProvinceID { get; set; }
        public string Province { get; set; }
         
    }
}
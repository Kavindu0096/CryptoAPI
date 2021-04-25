using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class CurrencyObj
    {
        public int ID { get; set; }
        public string Currency { get; set; }
        public string CurrencyDescription { get; set; }
        public int CreatedBy { get; set; }
    }
}
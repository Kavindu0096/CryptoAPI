using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class MainCurrencyObj
    {
        public int ID { get; set; }
        public string MainCurrency { get; set; }
        public string MainCurrencyDescription { get; set; }
        public int CreatedBy { get; set; }
    }
}
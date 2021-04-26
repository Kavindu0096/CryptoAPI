using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class CurrencyRate
    {
        public int ID { get; set; }
        public int CurrencyID { get; set; }
        public string Currency { get; set; }
        public string CurrencyDescription { get; set; }
        public int MainCurrencyID { get; set; }
        public string MainCurrency { get; set; }
        public string MainCurrencyDescription { get; set; }
        public double Rate { get; set; }

        public int CreatedBy { get; set; }
    }
}
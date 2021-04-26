using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int CurrencyID { get; set; }
        public string Currency { get; set; }
        public string CurrencyDescription { get; set; }
        public double ReceivedAmount { get; set; }
        public double CurrencyRate { get; set; }
        public double ConvertedAmount { get; set; }
        public int CreatedBy { get; set; }
    }
}
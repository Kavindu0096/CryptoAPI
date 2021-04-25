using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class ContentDetail
    {
        public int ID { get; set; }
        public int HeaderID { get; set; }
        public string SubLesson { get; set; }
        public int NoOfPeriods { get; set; }
        public int PrecentageFromLesson { get; set; }
        public string Remarks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
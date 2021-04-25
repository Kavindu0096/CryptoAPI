using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class SchoolObj
    {
        public int ID { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        public int TotalTeachers { get; set; }
        public int TotalStudents { get; set; }
        public int DivisionID { get; set; }
        public string Division { get; set; }
        public int ZoneID { get; set; }
        public string Zone { get; set; }
        public int ProvinceID { get; set; }
        public string Province { get; set; }
    }
}
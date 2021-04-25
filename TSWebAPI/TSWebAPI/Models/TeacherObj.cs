using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class TeacherObj
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SchoolID { get; set; }
        public string SchoolName { get; set; }
        public int DivisionID { get; set; }
        public string Division { get; set; }

        public int ZoneID { get; set; }
        public string Zone { get; set; }

        public int ProvinceID { get; set; }
        public string Province { get; set; }

        public string UserName { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }


    }
}
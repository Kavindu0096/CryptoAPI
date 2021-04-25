using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class TeacherContentDetail
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public int GradeID { get; set; }
        public string Grade { get; set; }
        public int SubjectID { get; set; }
        public string Subject { get; set; }

        public int ContentHeaderID { get; set; }

        public int ContentDetailID { get; set; }
        public string SubLesson { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public int ReasonID { get; set; }
        public string Reason { get; set; }
        public string ReasonComment { get; set; }

        public string Comment { get; set; }
        public int CreatedBy { get; set; }
        
    }
}
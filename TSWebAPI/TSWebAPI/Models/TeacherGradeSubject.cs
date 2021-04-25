using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class TeacherGradeSubject
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public int GradeID { get; set; }
        public string Grade { get; set; }
        public int SubjectID { get; set; }
        public string Subject { get; set; }
    }
}
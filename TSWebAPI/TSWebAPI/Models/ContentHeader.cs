using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSWebAPI.Models
{
    public class ContentHeader
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public string Subject { get; set; }
        public int GradeID { get; set; }
        public string Grade { get; set; }
        public string LessonDescription { get; set; }
        public int SubLessonCount { get; set; }
        public int TotalPeriods { get; set; }
        public int CreatedBy { get; set; }
        
        public List<ContentDetail> ContentDetails { get; set; }
    }
}
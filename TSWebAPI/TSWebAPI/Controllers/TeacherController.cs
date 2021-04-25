using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TSWebAPI.Common;
using TSWebAPI.Models;


namespace TSWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TeacherController : ApiController
    {
       
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

   
        [HttpPost, ActionName("RegisterTeacher")]
        public PostStatus RegisterTeacher(TeacherObj TeacherData)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_CREATE_Teacher '" + TeacherData.Name + "','" + TeacherData.Email + "','" + TeacherData.SchoolID + "','" + TeacherData.CreatedBy + "'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    string retStatus="";
                    while (rs.Read())
                    {
                        retStatus = rs["ReturnStatus"].ToString();
                    }
                    return CommonObj.GetPostStatus(retStatus);

                }
            }
            catch (Exception ex)
            {
                return CommonObj.GetPostStatusERROR(ex);
            }
        }

        [HttpGet, ActionName("GetTeachers")]
        public List<TeacherObj> GetTeachers(int ID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_Teachers " + ID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<TeacherObj> Teacher_List = new List<TeacherObj>();

                    while (rs.Read())
                    {
                        TeacherObj Teacher_Obj = new TeacherObj();
                        Teacher_Obj.ID = Convert.ToInt32(rs["ID"]);
                        Teacher_Obj.Code = rs["Code"].ToString();
                        Teacher_Obj.Name = rs["Name"].ToString();
                        Teacher_Obj.Email = rs["Email"].ToString();
                        Teacher_Obj.SchoolName = rs["SchoolName"].ToString();
                        Teacher_Obj.UserName = rs["UserName"].ToString();

                        Teacher_Obj.DivisionID = Convert.ToInt32(rs["DivisionID"]);
                        Teacher_Obj.Division = rs["Division"].ToString();

                        Teacher_Obj.ZoneID = Convert.ToInt32(rs["ZoneID"]);
                        Teacher_Obj.Zone = rs["Zone"].ToString();

                        Teacher_Obj.ProvinceID = Convert.ToInt32(rs["ProvinceID"]);
                        Teacher_Obj.Province = rs["Province"].ToString();

                        Teacher_List.Add(Teacher_Obj);

                    }
                    return Teacher_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet, ActionName("AddTeacherGradeSubjects")]
        public PostStatus AddTeacherGradeSubjects(int TeacherID,int GradeID,int SubjectID,int CreatedBy)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MA_CREATE_TeacherGradeSubjects '" + TeacherID + "','" + GradeID+ "','" + SubjectID + "','" + CreatedBy+ "'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    string retStatus = "";
                    while (rs.Read())
                    {
                        retStatus = rs["ReturnStatus"].ToString();
                    }
                    return CommonObj.GetPostStatus(retStatus);

                }
            }
            catch (Exception ex)
            {
                return CommonObj.GetPostStatusERROR(ex);
            }
        }

        [HttpGet, ActionName("GetTeacherGradeSubjects")]
        public List<TeacherGradeSubject> GetTeacherGradeSubjects(int TeacherID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_TeacherGradeSubjects " + TeacherID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<TeacherGradeSubject> TeacherGradeSubject_List = new List<TeacherGradeSubject>();

                    while (rs.Read())
                    {
                        TeacherGradeSubject TeacherGradeSubject_Obj = new TeacherGradeSubject();
                        TeacherGradeSubject_Obj.ID = Convert.ToInt32(rs["ID"]);
                        TeacherGradeSubject_Obj.TeacherID = Convert.ToInt32(rs["TeacherID"]);
                        TeacherGradeSubject_Obj.TeacherName = rs["TeacherName"].ToString();

                        TeacherGradeSubject_Obj.GradeID = Convert.ToInt32(rs["GradeID"]);
                        TeacherGradeSubject_Obj.Grade = rs["Grade"].ToString();

                        TeacherGradeSubject_Obj.SubjectID = Convert.ToInt32(rs["SubjectID"]);
                        TeacherGradeSubject_Obj.Subject = rs["Subject"].ToString();


                        TeacherGradeSubject_List.Add(TeacherGradeSubject_Obj);

                    }
                    return TeacherGradeSubject_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        [HttpGet, ActionName("GetTeachersGrades")]
        public List<Grade> GetTGrades(int TeacherID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_TeacherGrades " + TeacherID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<Grade> Grade_List = new List<Grade>();

                    while (rs.Read())
                    {
                        Grade Grade_Obj = new Grade();
                        Grade_Obj.ID = Convert.ToInt32(rs["ID"]);
                        Grade_Obj.Code = rs["Code"].ToString();
                        Grade_Obj.Description = rs["Description"].ToString();

                        Grade_List.Add(Grade_Obj);

                    }
                    return Grade_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        [HttpGet, ActionName("GetTeachersSubjects")]
        public List<SubjectObj> GetSubjects(int TeacherID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_TeacherSubjects " + TeacherID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<SubjectObj> Subject_List = new List<SubjectObj>();

                    while (rs.Read())
                    {
                        SubjectObj Subject_Obj = new SubjectObj();
                        Subject_Obj.ID = Convert.ToInt32(rs["ID"]);
                        Subject_Obj.Subject = rs["Subject"].ToString();
                        Subject_Obj.Description = rs["Description"].ToString();

                        Subject_List.Add(Subject_Obj);

                    }
                    return Subject_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet, ActionName("RemoveTeacherGradeSubjects")]
        public PostStatus RemoveTeacherGradeSubjects(int TeacherID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_DELETE_TeacherGradSubjects " + TeacherID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    string retStatus = "";
                    while (rs.Read())
                    {
                        retStatus = rs["ReturnStatus"].ToString();
                    }
                    return CommonObj.GetPostStatus(retStatus);

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
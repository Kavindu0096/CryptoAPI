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
    public class ContentController : ApiController
    {

        [HttpPost, ActionName("CreateContent")]
        public PostStatus CreateContent(ContentHeader ContentData)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_CREATE_ContentHeader '" + ContentData.SubjectID + "','" + ContentData.GradeID + "','" + ContentData.LessonDescription + "','" + ContentData.CreatedBy + "'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    string retStatus = "";
                    string ReturnID = "";
                    while (rs.Read())
                    {
                        retStatus = rs["ReturnStatus"].ToString();
                        ReturnID = rs["ReturnID"].ToString();
                    }
                    rs.Close();
                   if (ReturnID != "0")
                    {
                        foreach (ContentDetail ContentDetailObj in ContentData.ContentDetails)
                        {
                            string Sql1 = "";
                            Sql1 = "EXEC SP_MD_CREATE_ContentDetails '" + ReturnID + "','" + ContentDetailObj.SubLesson + "','" + ContentDetailObj.NoOfPeriods + "','" + ContentDetailObj.PrecentageFromLesson + "','" + ContentDetailObj.Remarks + "','" + ContentDetailObj.StartDate + "','" + ContentDetailObj.EndDate + "','" + ContentDetailObj.CreatedBy + "'";
                            string retDetailStatus = "";
                            SqlCommand cmd1 = new SqlCommand(Sql1, con);
                            SqlDataReader rs1 = cmd1.ExecuteReader();
                            while (rs1.Read())
                            {
                                retDetailStatus = rs1["ReturnStatus"].ToString();
                            }

                        }
                    }
                     


                    return CommonObj.GetPostStatus(retStatus);

                }
            }
            catch (Exception ex)
            {
                return CommonObj.GetPostStatusERROR(ex);
            }
        }

        [HttpGet, ActionName("GetContentList")]
        public List<ContentHeader> GetContentList(int SubjectID, int GradeID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_ContentList " + SubjectID + "," + GradeID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<ContentHeader> ContentHeader_List = new List<ContentHeader>();

                    while (rs.Read())
                    {
                        ContentHeader ContentHeader_Obj = new ContentHeader();
                        ContentHeader_Obj.ID = Convert.ToInt32(rs["ID"]);
                        ContentHeader_Obj.SubjectID = Convert.ToInt32(rs["SubjectID"]);
                        ContentHeader_Obj.Subject = rs["Subject"].ToString();

                        ContentHeader_Obj.GradeID = Convert.ToInt32(rs["GradeID"]);
                        ContentHeader_Obj.Grade = rs["Grade"].ToString();

                        ContentHeader_Obj.LessonDescription = rs["LessonDescription"].ToString();
                        ContentHeader_Obj.SubLessonCount = Convert.ToInt32(rs["SubLessonCount"]);
                        ContentHeader_Obj.TotalPeriods = Convert.ToInt32(rs["TotalPeriods"]);


                        ContentHeader_List.Add(ContentHeader_Obj);

                    }
                    return ContentHeader_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        [HttpGet, ActionName("GetContentByID")]
        public  ContentHeader  GetContentByID(int ID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_ContentHeader " + ID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                     ContentHeader ContentHeader_Obj = new  ContentHeader();

                    while (rs.Read())
                    {
                        
                        ContentHeader_Obj.ID = Convert.ToInt32(rs["ID"]);
                        ContentHeader_Obj.SubjectID = Convert.ToInt32(rs["SubjectID"]);
                        ContentHeader_Obj.Subject = rs["Subject"].ToString();

                        ContentHeader_Obj.GradeID = Convert.ToInt32(rs["GradeID"]);
                        ContentHeader_Obj.Grade = rs["Grade"].ToString();

                        ContentHeader_Obj.LessonDescription = rs["LessonDescription"].ToString();

                        rs.Close();

                        string Sql1 = "";
                        Sql1 = "EXEC SP_MD_GET_ContentDetails " + ID + "";

                        SqlCommand cmd1 = new SqlCommand(Sql1, con);
                        SqlDataReader rs1 = cmd1.ExecuteReader();
                        List<ContentDetail> ContentDetail_List = new List<ContentDetail>();
                        while (rs1.Read())
                        {
                            ContentDetail ContentDetail_Obj = new ContentDetail();
                            ContentDetail_Obj.ID = Convert.ToInt32(rs1["ID"]);
                            ContentDetail_Obj.HeaderID = Convert.ToInt32(rs1["HeaderID"]);
                            ContentDetail_Obj.SubLesson = rs1["SubLesson"].ToString();
                            ContentDetail_Obj.NoOfPeriods = Convert.ToInt32(rs1["NoOfPeriods"]);
                            ContentDetail_Obj.PrecentageFromLesson = Convert.ToInt32(rs1["PrecentageFromLesson"]);
                            ContentDetail_Obj.Remarks = rs1["Remarks"].ToString();
                            ContentDetail_Obj.StartDate = Convert.ToDateTime(rs1["StartDate"].ToString());
                            ContentDetail_Obj.EndDate = Convert.ToDateTime(rs1["EndDate"].ToString());

                            ContentDetail_List.Add(ContentDetail_Obj);
                        }
                        ContentHeader_Obj.ContentDetails = ContentDetail_List;
                        break;

                    }
                    return ContentHeader_Obj;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet, ActionName("GetContentDetailListByID")]
        public List<ContentDetail> GetContentDetailListByID(int ID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                List<ContentDetail> ContentDetail_List = new List<ContentDetail>();
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                        string Sql = "";
                        Sql = "EXEC SP_MD_GET_ContentDetails " + ID + "";

                        SqlCommand cmd = new SqlCommand(Sql, con);
                        SqlDataReader rs = cmd.ExecuteReader();
                    
                        while (rs.Read())
                        {
                            ContentDetail ContentDetail_Obj = new ContentDetail();
                            ContentDetail_Obj.ID = Convert.ToInt32(rs["ID"]);
                            ContentDetail_Obj.HeaderID = Convert.ToInt32(rs["HeaderID"]);
                            ContentDetail_Obj.SubLesson = rs["SubLesson"].ToString();
                            ContentDetail_Obj.NoOfPeriods = Convert.ToInt32(rs["NoOfPeriods"]);
                            ContentDetail_Obj.PrecentageFromLesson = Convert.ToInt32(rs["PrecentageFromLesson"]);
                            ContentDetail_Obj.Remarks = rs["Remarks"].ToString();
                            ContentDetail_Obj.StartDate = Convert.ToDateTime(rs["StartDate"].ToString());
                            ContentDetail_Obj.EndDate = Convert.ToDateTime(rs["EndDate"].ToString());

                            ContentDetail_List.Add(ContentDetail_Obj);
                        }

                    }
                return ContentDetail_List;

          
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet, ActionName("GetContentTimeLineByDate")]
        public List<ContentHeader> GetContentTimeLineByDate(DateTime date, int SubjectID, int GradeID)
        {
            try
            {
               string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_TeachersTimeline '" + date.ToString("yyyy-MM-dd") + "'," + SubjectID + "," + GradeID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<ContentHeader> ContentHeader_List = new List<ContentHeader>();

                    while (rs.Read())
                    {
                        ContentHeader ContentHeader_Obj = new ContentHeader();
                        ContentHeader_Obj.ID = Convert.ToInt32(rs["ID"]);
                        ContentHeader_Obj.SubjectID = Convert.ToInt32(rs["SubjectID"]);
                        ContentHeader_Obj.Subject = rs["Subject"].ToString();

                        ContentHeader_Obj.GradeID = Convert.ToInt32(rs["GradeID"]);
                        ContentHeader_Obj.Grade = rs["Grade"].ToString();

                        ContentHeader_Obj.LessonDescription = rs["LessonDescription"].ToString();

                        ContentHeader_List.Add(ContentHeader_Obj);
                        

                    }
                    return ContentHeader_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost, ActionName("UpdateTeachersContent")]
        public PostStatus UpdateTeachersContent(TeacherContentDetail TeacherContent)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_UPDATE_TeachersContent '" + TeacherContent.TeacherID + "','" + TeacherContent.SubjectID + "','" + TeacherContent.GradeID + "','" + TeacherContent.ContentDetailID + "','" + TeacherContent.StatusID + "','" + TeacherContent.ReasonID + "','" + TeacherContent.ReasonComment + "','" + TeacherContent.Comment + "','" + TeacherContent.CreatedBy + "'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    string retStatus = "";
                    string ReturnID = "";
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

    }
}

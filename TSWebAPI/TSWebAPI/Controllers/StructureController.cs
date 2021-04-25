using System;
using System.Collections.Generic;
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
    public class StructureController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet, ActionName("getSequence")]
        public string GetSequence(string type)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_Sequence '" + type + "'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    string CODE = "";
                    while (rs.Read())
                    {
                        CODE = rs["CODE"].ToString();

                        break;


                    }
                    return CODE;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet, ActionName("GetProvinces")]
        public List<ProvinceObj> GetProvinces()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_REF_GET_Provinces ";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<ProvinceObj> Province_List = new List<ProvinceObj>();

                    while (rs.Read())
                    {
                        ProvinceObj province_Obj = new ProvinceObj();
                        province_Obj.ID = Convert.ToInt32(rs["ID"]);
                        province_Obj.Province = rs["Province"].ToString();

                        Province_List.Add(province_Obj);

                    }
                    return Province_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet, ActionName("GetZones")]
        public List<ZoneObj> GetZones(int provinceID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_REF_GET_Zones " + provinceID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<ZoneObj> Zone_List = new List<ZoneObj>();

                    while (rs.Read())
                    {
                        ZoneObj Zone_Obj = new ZoneObj();
                        Zone_Obj.ID = Convert.ToInt32(rs["ID"]);
                        Zone_Obj.Zone = rs["Zone"].ToString();
                        Zone_Obj.ProvinceID = Convert.ToInt32(rs["ProvinceID"]);
                        Zone_Obj.Province = rs["Province"].ToString();

                        Zone_List.Add(Zone_Obj);

                    }
                    return Zone_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }





        [HttpGet, ActionName("GetDeparments")]
        public List<DepartmentObj> GetDeparments()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_REF_GET_Departments ";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<DepartmentObj> DepartmentObj_List = new List<DepartmentObj>();

                    while (rs.Read())
                    {
                        DepartmentObj Department_Obj = new DepartmentObj();
                        Department_Obj.ID = Convert.ToInt32(rs["ID"]);
                        Department_Obj.Name = rs["Department"].ToString();

                        DepartmentObj_List.Add(Department_Obj);

                    }
                    return DepartmentObj_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet, ActionName("GetDivisions")]
        public List<DivisionObj> GetDivisions(int ZoneID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_REF_GET_Divisions " + ZoneID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<DivisionObj> Division_List = new List<DivisionObj>();

                    while (rs.Read())
                    {
                        DivisionObj Division_Obj = new DivisionObj();
                        Division_Obj.ID = Convert.ToInt32(rs["ID"]);
                        Division_Obj.Division = rs["Division"].ToString();
                        Division_Obj.ZoneID = Convert.ToInt32(rs["ZoneID"]);
                        Division_Obj.Zone = rs["Zone"].ToString();
                        Division_Obj.ProvinceID = Convert.ToInt32(rs["ProvinceID"]);
                        Division_Obj.Province = rs["Province"].ToString();

                        Division_List.Add(Division_Obj);

                    }
                    return Division_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet, ActionName("GetSchools")]
        public List<SchoolObj> GetSchools(int DivisionID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_REF_GET_Schools " + DivisionID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<SchoolObj> School_List = new List<SchoolObj>();

                    while (rs.Read())
                    {
                        SchoolObj School_Obj = new SchoolObj();
                        School_Obj.ID = Convert.ToInt32(rs["ID"]);
                        School_Obj.SchoolName = rs["SchoolName"].ToString();
                        School_Obj.Address = rs["Address"].ToString();
                        School_Obj.Email = rs["Email"].ToString();
                        School_Obj.TelNo = rs["TelNo"].ToString();
                        School_Obj.TotalTeachers = Convert.ToInt32(rs["TotalTeachers"]);
                        School_Obj.TotalStudents = Convert.ToInt32(rs["TotalStudents"]);
                        School_Obj.DivisionID = Convert.ToInt32(rs["DivisionID"]);
                        School_Obj.Division = rs["Division"].ToString();
                        School_Obj.ZoneID = Convert.ToInt32(rs["ZoneID"]);
                        School_Obj.Zone = rs["Zone"].ToString();
                        School_Obj.ProvinceID = Convert.ToInt32(rs["ProvinceID"]);
                        School_Obj.Province = rs["Province"].ToString();

                        School_List.Add(School_Obj);

                    }
                    return School_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet, ActionName("GetUserRoles")]
        public List<UserRoleObj> GetUserRoles()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_REF_GET_UserRoles ";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<UserRoleObj> UserRoleObj_List = new List<UserRoleObj>();

                    while (rs.Read())
                    {
                        UserRoleObj UserRole_Obj = new UserRoleObj();
                        UserRole_Obj.ID = Convert.ToInt32(rs["ID"]);
                        UserRole_Obj.Name = rs["UserRole"].ToString();

                        UserRoleObj_List.Add(UserRole_Obj);

                    }
                    return UserRoleObj_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet, ActionName("GetGrades")]
        public List<Grade> GetTGrades()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_Grades";

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



        [HttpGet, ActionName("GetSubjects")]
        public List<SubjectObj> GetSubjects()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_Subjects";

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



        [HttpGet, ActionName("GetStatus")]
        public List<StatusObj> GetStatus()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_Status";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<StatusObj> StatusObj_List = new List<StatusObj>();

                    while (rs.Read())
                    {
                        StatusObj Status_Obj = new StatusObj();
                        Status_Obj.ID = Convert.ToInt32(rs["ID"]);
                        Status_Obj.Status = rs["Status"].ToString();


                        StatusObj_List.Add(Status_Obj);

                    }
                    return StatusObj_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet, ActionName("GetReasons")]
        public List<ReasonObj> GetReasons()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_Reasons";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();
                    List<ReasonObj> ReasonObj_List = new List<ReasonObj>();

                    while (rs.Read())
                    {
                        ReasonObj Reasons_Obj = new ReasonObj();
                        Reasons_Obj.ID = Convert.ToInt32(rs["ID"]);
                        Reasons_Obj.Reason = rs["Reason"].ToString();


                        ReasonObj_List.Add(Reasons_Obj);

                    }
                    return ReasonObj_List;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
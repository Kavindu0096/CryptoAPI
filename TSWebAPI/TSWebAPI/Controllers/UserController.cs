using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using TSWebAPI.Common;
using TSWebAPI.Models;

namespace TSWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {




        public List<User> GetUsers()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_User 0";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    List<User> UserList = new List<User>();

                    while (rs.Read())
                    {
                        User userObj = new User();
                        userObj.ID = int.Parse(rs["ID"].ToString());
                        userObj.UserName = rs["UserName"].ToString();
                        userObj.Email = rs["Email"].ToString();

                        UserList.Add(userObj);
                    }
                    return UserList;



                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public User GetUserByID(int ID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_User " + ID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    User userObj = new User();

                    while (rs.Read())
                    {

                        userObj.ID = int.Parse(rs["ID"].ToString());
                        userObj.UserName = rs["UserName"].ToString();
                        userObj.Email = rs["Email"].ToString();


                    }
                    if (userObj.ID != 0)
                    {
                        return userObj;
                    }
                    else
                    {
                        return null;
                    }




                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PostStatus CreateUser(User UserData)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_CREATE_User '" + UserData.UserName + "','" + UserData.Email + "','" + UserData.Password + "','" + UserData.EncryptedPassword + "','" + UserData.CreatedBy + "'";

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

        public PostStatus UpdateUser(User UserData)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return CommonObj.GetCustomERROR("Invalid Atributes");
                }
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_UPDATE_User '" + UserData.ID + "','" + UserData.Email + "','" + UserData.Password + "','" + UserData.EncryptedPassword + "','" + UserData.CreatedBy + "'";

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
        public PostStatus DeleteUser(int id)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_DELETE_User '" + id + "'";

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

    }
}
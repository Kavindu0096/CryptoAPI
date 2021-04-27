using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TSWebAPI.Models;
using TSWebAPI.Support;

namespace TSWebAPI.Controllers
{
    public class AuthenticationController : ApiController
    {
        public LoginResponse Login(Login LoginObj)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_UserByUserName '" + LoginObj.UserName + "'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    LoginResponse LoginResponseObj = new LoginResponse();

                    while (rs.Read())
                    {


                        LoginResponseObj.ID = int.Parse(rs["ID"].ToString());
                        LoginResponseObj.UserName = rs["UserName"].ToString();
                        LoginResponseObj.Email = rs["Email"].ToString();
                        LoginResponseObj.Password = rs["Email"].ToString();
                        LoginResponseObj.EncryptedPassword = rs["EncryptedPassword"].ToString();

                       
                    }

                   
                    PostStatus PostStatusObj = new PostStatus();
                    if (LoginResponseObj.ID == 0)
                    {
                        PostStatusObj.UniqueNo = "1";
                        PostStatusObj.ErrorId = 1;
                        PostStatusObj.ErrorDescription = "Invalid User";
                        PostStatusObj.ErrorClass = "alert-danger";

                        LoginResponseObj = new LoginResponse();
                        LoginResponseObj.PostStatusObj = PostStatusObj;
                        return LoginResponseObj;
                    }

                    // string parmDereyptedPW = ClsEncryption.Decrypt(LoginObj.Password);
                    string dbDereyptedPW = ClsEncryption.Decrypt(LoginResponseObj.EncryptedPassword);

                   


                    
                    if (LoginObj.Password.Equals(dbDereyptedPW))
                    {

                        PostStatusObj.UniqueNo = "0";
                        PostStatusObj.ErrorId = 0;
                        PostStatusObj.ErrorClass = "alert-success";

                        LoginResponseObj.PostStatusObj = PostStatusObj;
                        return LoginResponseObj;
                    }
                    else
                    {
                        PostStatusObj.UniqueNo = "1";
                        PostStatusObj.ErrorId = 1;
                        PostStatusObj.ErrorDescription = "Incorrect Password";
                        PostStatusObj.ErrorClass = "alert-danger";
                        LoginResponseObj = new LoginResponse();
                        LoginResponseObj.PostStatusObj = PostStatusObj;
                        return LoginResponseObj;
                    }
                    



                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

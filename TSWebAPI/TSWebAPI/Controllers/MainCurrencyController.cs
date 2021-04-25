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
    public class MainCurrencyController : ApiController
    {



        public List<MainCurrencyObj> GetMainCurrency()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_MainCurrency 0";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    List<MainCurrencyObj> MainCurrencyList = new List<MainCurrencyObj>();

                    while (rs.Read())
                    {
                        MainCurrencyObj MainCurrency_Obj = new MainCurrencyObj();
                        MainCurrency_Obj.ID = int.Parse(rs["ID"].ToString());
                        MainCurrency_Obj.MainCurrency = rs["MainCurrency"].ToString();
                        MainCurrency_Obj.MainCurrencyDescription = rs["MainCurrencyDescription"].ToString();

                        MainCurrencyList.Add(MainCurrency_Obj);
                    }

                    return MainCurrencyList;



                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public MainCurrencyObj GetMainCurrencyByID(int ID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_MainCurrency " + ID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    MainCurrencyObj MainCurrency_Obj = new MainCurrencyObj();

                    while (rs.Read())
                    {

                        MainCurrency_Obj.ID = int.Parse(rs["ID"].ToString());
                        MainCurrency_Obj.MainCurrency = rs["MainCurrency"].ToString();
                        MainCurrency_Obj.MainCurrencyDescription = rs["MainCurrencyDescription"].ToString();


                    }
                    if (MainCurrency_Obj.ID != 0)
                    {
                        return MainCurrency_Obj;
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

        public PostStatus AddMainCurrency(MainCurrencyObj MainCurrencyObj)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_CREATE_MainCurrency '" + MainCurrencyObj.MainCurrency + "','" + MainCurrencyObj.MainCurrencyDescription + "','" + MainCurrencyObj.CreatedBy + "'";

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

        public PostStatus UpdateMainCurrency(MainCurrencyObj MainCurrencyObj)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_UPDATE_MainCurrency '" + MainCurrencyObj.ID + "','" + MainCurrencyObj.MainCurrency + "','" + MainCurrencyObj.MainCurrencyDescription + "','" + MainCurrencyObj.CreatedBy + "'";

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
                    Sql = "EXEC SP_MD_DELETE_MainCurrency '" + id + "'";

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

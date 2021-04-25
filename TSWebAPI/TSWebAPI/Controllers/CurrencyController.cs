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
    public class CurrencyController : ApiController
    {



        public List<CurrencyObj> GetCurrency()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_Currency 0";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    List<CurrencyObj> CurrencyList = new List<CurrencyObj>();

                    while (rs.Read())
                    {
                        CurrencyObj Currency_Obj = new CurrencyObj();
                        Currency_Obj.ID = int.Parse(rs["ID"].ToString());
                        Currency_Obj.Currency = rs["Currency"].ToString();
                        Currency_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();

                        CurrencyList.Add(Currency_Obj);
                    }

                    return CurrencyList;



                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CurrencyObj GetCurrencyByID(int ID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_Currency " + ID + "";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    CurrencyObj Currency_Obj = new CurrencyObj();

                    while (rs.Read())
                    {

                        Currency_Obj.ID = int.Parse(rs["ID"].ToString());
                        Currency_Obj.Currency = rs["Currency"].ToString();
                        Currency_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();


                    }
                    if (Currency_Obj.ID != 0)
                    {
                        return Currency_Obj;
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

        public PostStatus AddCurrency(CurrencyObj CurrencyObj)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_CREATE_Currency '" + CurrencyObj.Currency + "','" + CurrencyObj.CurrencyDescription + "','" + CurrencyObj.CreatedBy + "'";

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

        public PostStatus UpdateCurrency(CurrencyObj CurrencyObj)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_UPDATE_Currency '" + CurrencyObj.ID + "','" + CurrencyObj.Currency + "','" + CurrencyObj.CurrencyDescription + "','" + CurrencyObj.CreatedBy + "'";

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
                    Sql = "EXEC SP_MD_DELETE_Currency '" + id + "'";

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

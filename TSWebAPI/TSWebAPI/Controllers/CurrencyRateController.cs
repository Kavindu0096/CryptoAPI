using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TSWebAPI.Common;
using TSWebAPI.Models;

namespace TSWebAPI.Controllers
{
    public class CurrencyRateController : ApiController
    {

        public List<CurrencyRate> GetCurrencyRates()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_CurrencyRate 0,''";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    List<CurrencyRate> CurrencyRateList = new List<CurrencyRate>();

                    while (rs.Read())
                    {
                        CurrencyRate CurrencyRate_Obj = new CurrencyRate();
                        CurrencyRate_Obj.ID = int.Parse(rs["ID"].ToString());
                        CurrencyRate_Obj.CurrencyID = int.Parse(rs["CurrencyID"].ToString());
                        CurrencyRate_Obj.Currency = rs["Currency"].ToString();
                        CurrencyRate_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();

                        CurrencyRate_Obj.MainCurrencyID = int.Parse(rs["MainCurrencyID"].ToString());
                        CurrencyRate_Obj.MainCurrency = rs["MainCurrency"].ToString();
                        CurrencyRate_Obj.MainCurrencyDescription = rs["MainCurrencyDescription"].ToString();

                        CurrencyRate_Obj.Rate = double.Parse(rs["Rate"].ToString());

                        CurrencyRateList.Add(CurrencyRate_Obj);
                    }

                    return CurrencyRateList;



                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CurrencyRate GetCurrencyRateByID(int ID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_CurrencyRate " + ID + ",'ID'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    CurrencyRate CurrencyRate_Obj = new CurrencyRate();

                    while (rs.Read())
                    {

                        CurrencyRate_Obj.ID = int.Parse(rs["ID"].ToString());
                        CurrencyRate_Obj.CurrencyID = int.Parse(rs["CurrencyID"].ToString());
                        CurrencyRate_Obj.Currency = rs["Currency"].ToString();
                        CurrencyRate_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();

                        CurrencyRate_Obj.MainCurrencyID = int.Parse(rs["MainCurrencyID"].ToString());
                        CurrencyRate_Obj.MainCurrency = rs["MainCurrency"].ToString();
                        CurrencyRate_Obj.MainCurrencyDescription = rs["MainCurrencyDescription"].ToString();

                        CurrencyRate_Obj.Rate = double.Parse(rs["Rate"].ToString());




                    }
                    if (CurrencyRate_Obj.ID != 0)
                    {
                        return CurrencyRate_Obj;
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

        public CurrencyRate GetCurrencyRateByCurrencyID(int CurrencyID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_CurrencyRate " + CurrencyID + ",'Currency'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    CurrencyRate CurrencyRate_Obj = new CurrencyRate();

                    while (rs.Read())
                    {

                        CurrencyRate_Obj.ID = int.Parse(rs["ID"].ToString());
                        CurrencyRate_Obj.CurrencyID = int.Parse(rs["CurrencyID"].ToString());
                        CurrencyRate_Obj.Currency = rs["Currency"].ToString();
                        CurrencyRate_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();

                        CurrencyRate_Obj.MainCurrencyID = int.Parse(rs["MainCurrencyID"].ToString());
                        CurrencyRate_Obj.MainCurrency = rs["MainCurrency"].ToString();
                        CurrencyRate_Obj.MainCurrencyDescription = rs["MainCurrencyDescription"].ToString();

                        CurrencyRate_Obj.Rate = double.Parse(rs["Rate"].ToString());

                        


                    }
                    if (CurrencyRate_Obj.ID != 0)
                    {
                        return CurrencyRate_Obj;
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



        public CurrencyRate GetCurrencyRateByMainCurrencyID(int MainCurrencyID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_CurrencyRate " + MainCurrencyID + ",'MainCurrency'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    CurrencyRate CurrencyRate_Obj = new CurrencyRate();

                    while (rs.Read())
                    {

                        CurrencyRate_Obj.ID = int.Parse(rs["ID"].ToString());
                        CurrencyRate_Obj.CurrencyID = int.Parse(rs["CurrencyID"].ToString());
                        CurrencyRate_Obj.Currency = rs["Currency"].ToString();
                        CurrencyRate_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();

                        CurrencyRate_Obj.MainCurrencyID = int.Parse(rs["MainCurrencyID"].ToString());
                        CurrencyRate_Obj.MainCurrency = rs["MainCurrency"].ToString();
                        CurrencyRate_Obj.MainCurrencyDescription = rs["MainCurrencyDescription"].ToString();

                        CurrencyRate_Obj.Rate = double.Parse(rs["Rate"].ToString());




                    }
                    if (CurrencyRate_Obj.ID != 0)
                    {
                        return CurrencyRate_Obj;
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


        public PostStatus AddCurrencyRate(CurrencyRate CurrencyRateObj)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_ADD_CurrencyRate '" + CurrencyRateObj.CurrencyID + "','" + CurrencyRateObj.MainCurrencyID + "','" + CurrencyRateObj.Rate + "','" + CurrencyRateObj.CreatedBy + "'";

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

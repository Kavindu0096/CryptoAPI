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
    public class OrderController : ApiController
    {
        public List<Order> GetOrders()
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_OrderDetails 0,''";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    List<Order> OrderList = new List<Order>();

                    while (rs.Read())
                    {
                        Order Order_Obj = new Order();
                        Order_Obj.ID = int.Parse(rs["ID"].ToString());
                        Order_Obj.UserID = int.Parse(rs["UserID"].ToString());
                        Order_Obj.UserName = rs["UserName"].ToString();
                        Order_Obj.CurrencyID = int.Parse(rs["CurrencyID"].ToString());
                        Order_Obj.Currency = rs["Currency"].ToString();
                        Order_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();
                        Order_Obj.ReceivedAmount = double.Parse(rs["ReceivedAmount"].ToString());
                        Order_Obj.CurrencyRate = double.Parse(rs["CurrencyRate"].ToString());
                        Order_Obj.ConvertedAmount = double.Parse(rs["ConvertedAmount"].ToString()); 



                        OrderList.Add(Order_Obj);
                    }

                    return OrderList;



                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Order GetOrderByID(int ID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_OrderDetails " + ID + ",'ID'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    Order Order_Obj = new Order();

                    while (rs.Read())
                    {

                       
                        Order_Obj.ID = int.Parse(rs["ID"].ToString());
                        Order_Obj.UserID = int.Parse(rs["UserID"].ToString());
                        Order_Obj.UserName = rs["UserName"].ToString();
                        Order_Obj.CurrencyID = int.Parse(rs["CurrencyID"].ToString());
                        Order_Obj.Currency = rs["Currency"].ToString();
                        Order_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();
                        Order_Obj.ReceivedAmount = double.Parse(rs["ReceivedAmount"].ToString());
                        Order_Obj.CurrencyRate = double.Parse(rs["CurrencyRate"].ToString());
                        Order_Obj.ConvertedAmount = double.Parse(rs["ConvertedAmount"].ToString()); 


                    }
                    if (Order_Obj.ID != 0)
                    {
                        return Order_Obj;
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

        public Order GetOrderByUserID(int UserID)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_GET_OrderDetails " + UserID + ",'ID'";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataReader rs = cmd.ExecuteReader();

                    Order Order_Obj = new Order();

                    while (rs.Read())
                    {


                        Order_Obj.ID = int.Parse(rs["ID"].ToString());
                        Order_Obj.UserID = int.Parse(rs["UserID"].ToString());
                        Order_Obj.UserName = rs["UserName"].ToString();
                        Order_Obj.CurrencyID = int.Parse(rs["CurrencyID"].ToString());
                        Order_Obj.Currency = rs["Currency"].ToString();
                        Order_Obj.CurrencyDescription = rs["CurrencyDescription"].ToString();
                        Order_Obj.ReceivedAmount = double.Parse(rs["ReceivedAmount"].ToString());
                        Order_Obj.CurrencyRate = double.Parse(rs["CurrencyRate"].ToString());
                        Order_Obj.ConvertedAmount = double.Parse(rs["ConvertedAmount"].ToString());


                    }
                    if (Order_Obj.ID != 0)
                    {
                        return Order_Obj;
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
        public PostStatus PostOrder(Order OrderObj)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_CREATE_Order '" + OrderObj.UserID + "','" + OrderObj.CurrencyID + "','" + OrderObj.ReceivedAmount + "','" + OrderObj.CurrencyRate + "','" + OrderObj.ConvertedAmount + "'";

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

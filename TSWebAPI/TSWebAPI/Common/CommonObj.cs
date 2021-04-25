using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSWebAPI.Models;

namespace TSWebAPI.Common
{
    public static class CommonObj
    {
        public static PostStatus GetPostStatus(string result)
        {
            PostStatus objMessage = new PostStatus();
            string[] ReturnStatus;
            if (result == null || result == "")
            {
                objMessage.UniqueNo = "1";
                objMessage.ErrorId = 1;
                objMessage.ErrorClass = "alert-danger";
                return objMessage;
            }
           ReturnStatus = result.Split(',');

            if (Convert.ToInt32(ReturnStatus[0]) == 0)
            {
                objMessage.UniqueNo = "0";
                objMessage.ErrorId = 0;
                objMessage.ErrorClass = "alert-success";
            }
            else if (Convert.ToInt32(ReturnStatus[0]) == 2)
            {
                objMessage.UniqueNo = "2";
                objMessage.ErrorId = 2;
                objMessage.ErrorClass = "alert-warning";
            }
            else
            {
                objMessage.UniqueNo = "1";
                objMessage.ErrorId = 1;
                objMessage.ErrorClass = "alert-danger";
            }
            objMessage.ErrorDescription = ReturnStatus[1].ToString();

            return objMessage;
        }

        public static PostStatus GetCustomERROR(string error)
        {
            PostStatus objMessage = new PostStatus();
            objMessage.UniqueNo = "1";
            objMessage.ErrorId = 1;
            objMessage.ErrorDescription = error;
            objMessage.ErrorClass = "alert-danger";

            return objMessage;
        }

        public static PostStatus GetPostStatusERROR(Exception error)
        {
            PostStatus objMessage = new PostStatus();
            objMessage.UniqueNo = "1";
            objMessage.ErrorId = 1;
            objMessage.ErrorDescription = error.InnerException.Message;
            objMessage.ErrorClass = "alert-danger";

            return objMessage;
        }


    }
}
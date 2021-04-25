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
    public class SignUpController : ApiController
    {
        ObjectParameter returnStatus = new ObjectParameter("ReturnStatus", 0);

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public PostStatus Post(User UserData)
        {
            try
            {
                string strCNN = System.Configuration.ConfigurationManager.AppSettings["CON"];
                using (SqlConnection con = new SqlConnection(strCNN))
                {
                    con.Open();

                    string Sql = "";
                    Sql = "EXEC SP_MD_CREATE_User '" + UserData.UserName + "','" + UserData.Email + "','" + UserData.Password + "','" + UserData.EncryptedPassword + "',1,'" + returnStatus + "'";
                    return CommonObj.GetPostStatus(returnStatus.Value.ToString());

                }
            }
            catch (Exception ex) {
                return CommonObj.GetPostStatusERROR(ex);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
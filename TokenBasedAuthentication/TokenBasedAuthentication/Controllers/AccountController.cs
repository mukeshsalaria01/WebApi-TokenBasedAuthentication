using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TokenBasedAuthentication.Helpers;

namespace TokenBasedAuthentication.Controllers
{
    public class AccountController : ApiController
    {
        //
        // GET: /Account/

        /// <summary>
        /// Login a client
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public IHttpActionResult Login(string email, string password = "password")
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var ip = HttpContext.Current.Request.UserHostAddress;
                    var agent = HttpContext.Current.Request.UserAgent;
                    var ticks = DateTime.UtcNow.Ticks; ;
                    var token = SecurityManager.GenerateToken(email, password, ip, agent, ticks);
                    return Ok(new { token });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Response = ex.Message });
            }
        }


    }
}

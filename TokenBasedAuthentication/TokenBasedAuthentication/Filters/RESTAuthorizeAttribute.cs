using System;
using System.Web;
using System.Web.Http.Controllers;
using TokenBasedAuthentication.Helpers;

namespace TokenBasedAuthentication.Filters
{
    /// <summary>
    /// Token-based authentication for ASP .NET MVC REST web services.
    /// Copyright (c) 2015 Kory Becker
    /// http://primaryobjects.com/kory-becker
    /// License MIT
    /// </summary>
    //    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class RESTAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private const string SecurityToken = "token";

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }

            HandleUnauthorizedRequest(filterContext);
        }

        protected void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        private static bool Authorize(HttpActionContext actionContext)
        {
            if (actionContext == null) throw new ArgumentNullException("actionContext");
            try
            {
                string token = null;
                var queryString = actionContext.Request.RequestUri.Query;
                if (!string.IsNullOrWhiteSpace(queryString))
                {
                    token = HttpUtility.ParseQueryString(
                                         queryString.Substring(1))[SecurityToken];
                }

                var ip = HttpContext.Current.Request.UserHostAddress;
                var agent = HttpContext.Current.Request.UserAgent;
                return SecurityManager.IsTokenValid(token, ip, agent);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
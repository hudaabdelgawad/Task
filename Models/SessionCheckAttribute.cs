using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Task.Models
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authCookie = filterContext.HttpContext.Request.Cookies["AuthToken"];
            if (authCookie != null)
            {
                var sessionToken = authCookie.Value;
                using (var context = new InvoiceDbContext())
                {
                    var user = context.Users.SingleOrDefault(u => u.SessionToken == sessionToken && u.SessionExpiry > DateTime.Now);
                    if (user != null)
                    {
                        base.OnActionExecuting(filterContext);
                        return;
                    }
                }
            }

            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                { "controller", "Account" },
                { "action", "Login" }
           });
        }
    }
}




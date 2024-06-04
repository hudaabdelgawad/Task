using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Task.Controllers
{
    public class BaseController : Controller
    {
       

        private const string DefaultLanguage = "ar-EG";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["lang"] == null)
            {
                // Set default language if not set
                Session["lang"] = DefaultLanguage;
            }

            // Set the culture based on the session value
            var lang = Session["lang"].ToString();
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            base.OnActionExecuting(filterContext);
        }
       

    }

}
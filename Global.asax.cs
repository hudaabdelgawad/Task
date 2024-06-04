using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;




namespace Task
{
    public class MvcApplication :HttpApplication
    {
        protected void Application_Start()
        {
            

            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<InvoiceDbContext>(new DropCreateDatabaseIfModelChanges<InvoiceDbContext>());
           
        }

      

    }
}

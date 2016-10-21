using System.Web.Mvc;
using System.Web.Routing;

namespace Claims.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

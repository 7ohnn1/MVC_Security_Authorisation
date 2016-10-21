using System.Collections.Generic;
using System.Web.Mvc;

namespace Claims.Web.Controllers
{
    public class HomeController : Controller{
        public ActionResult Index()
        {
            Dictionary <string, object> data = new Dictionary<string,object>();
            data.Add("Placeholder","Placeholder");
            return View(data);
        }
    }
}
using System.Security.Claims;
using System.Web.Mvc;
using Claims.Web.SecurityInfrastructure;

namespace Claims.Web.Controllers
{
    public class ClaimsController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            ClaimsIdentity ident = HttpContext.User.Identity as ClaimsIdentity;
            if (ident == null)
                return View("Error", new string[] { "No claims available" });
            else
                return View(ident.Claims);
        }
        
        [ClaimsAccess(Issuer = "RemoteClaims", ClaimType = ClaimTypes.PostalCode, Value = "DC 20500")]
        public string OtherAction()
        {
            return "You are granted access to this protected area :)";
        }

    }
}

using Microsoft.AspNet.Identity.EntityFramework;

namespace Claims.Model.IdentitySecurity
{
    public class AppRole : IdentityRole
    {

        public AppRole() : base() { }

        public AppRole(string name) : base(name) { }
    }
}

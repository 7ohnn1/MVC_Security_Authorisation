using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Claims.Model.IdentitySecurity;

namespace Claims.Db
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("IdentityDb")
        {
        }

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }


        //instance of the class are created via here when needed by the OWIN
        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }

    }

}
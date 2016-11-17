using System.Data.Entity.Migrations;
using Claims.Db;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Claims.Model.IdentitySecurity;
using Claims.Services.IdentitySecurity;

namespace Claims.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Claims.Web.SecurityInfrastructure.AppIdentityDbContext";
        }

        protected override void Seed(AppIdentityDbContext context)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            string roleName = "Administrator";
            string userName = "Admin";
            string password = "MySecret";
            string email = "admin@example.com";

            if (!roleMgr.RoleExists(roleName))
                roleMgr.Create(new AppRole(roleName));

            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleName))
                userMgr.AddToRole(user.Id, roleName);

            foreach (AppUser dbUser in userMgr.Users)
            {
                if (dbUser.Country == Countries.NONE)
                    dbUser.SetCountryFromCity(dbUser.City);
            }

            context.SaveChanges();
        }

    }
}

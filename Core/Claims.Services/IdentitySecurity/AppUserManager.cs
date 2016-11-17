using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Claims.Db;
using Claims.Model.IdentitySecurity;

namespace Claims.Services.IdentitySecurity
{
    //Manages user data
    public class AppUserManager : UserManager<AppUser>
    {
        //ChangePasswordAsync(id, old, new);
        //CreateAsync(user);
        //CreateAsync(user,pass);
        //DeleteAsync(user);
        //FindAsync(user, pass);
        //FindByIdAsync(id);
        //FindByNameAsync(name);
        //UpdateAsync(user);
        //Users

        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        public static AppUserManager Create(
                IdentityFactoryOptions<AppUserManager> options,
                IOwinContext context)
        {
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));

            manager.PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true
            };

            manager.UserValidator = new CustomUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            return manager;
        }

    }
}

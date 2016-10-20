using System.Linq;
using System.Threading.Tasks;
using Claims.Model;
using Microsoft.AspNet.Identity;

namespace Claims.Services
{

    public class CustomUserValidator : UserValidator<AppUser>
    {

        public CustomUserValidator(AppUserManager mgr)
            : base(mgr)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (!user.Email.ToLower().EndsWith("@example.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Only example.com email addresses are allowed");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}

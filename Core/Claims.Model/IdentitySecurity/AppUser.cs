using Microsoft.AspNet.Identity.EntityFramework;
using Claims.Model.IdentitySecurity;

namespace Claims.Model.IdentitySecurity
{

    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
        public Countries Country { get; set; }
        // additional properties will go here

        public void SetCountryFromCity(Cities city)
        {
            switch (city)
            {
                case Cities.LONDON:
                    Country = Countries.UK;
                    break;
                case Cities.PARIS:
                    Country = Countries.FRANCE;
                    break;
                case Cities.CHICAGO:
                    Country = Countries.USA;
                    break;
                default:
                    Country = Countries.NONE;
                    break;
            }
        }
    }

}

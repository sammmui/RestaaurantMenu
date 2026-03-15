using Microsoft.AspNetCore.Identity;

namespace LibraryWebApplication
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}


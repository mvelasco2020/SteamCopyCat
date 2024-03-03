using Microsoft.AspNetCore.Identity;

namespace SteamCopyCat.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

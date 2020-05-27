using Microsoft.AspNetCore.Identity;

namespace Battlenet.Web.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string CustomUserName { get; set; }
    }
}

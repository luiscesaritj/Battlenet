using Microsoft.AspNetCore.Identity;

namespace Battlenet.Web.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CustomUserName { get; set; }
    }
}

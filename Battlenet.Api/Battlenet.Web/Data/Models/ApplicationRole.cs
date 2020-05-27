using Microsoft.AspNetCore.Identity;

namespace Battlenet.Web.Data.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        public string RoleDescription { get; set; }
    }
}

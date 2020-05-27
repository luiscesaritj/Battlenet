using Battlenet.Web.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Battlenet.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=pgsql10-farm76.kinghost.net;Database=primarysoluction;Username=primarysoluction;Password=Nickteam@1");
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Connection> Connections { get; set; }
    }
}

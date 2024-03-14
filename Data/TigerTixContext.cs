using Microsoft.EntityFrameworkCore;

namespace TigerTix.Web.Data
{
    public class TigerTixContext : DbContext
    {
        public DbSet<Entities.User> Users {get;set;}
        private readonly IConfiguration _config;

        public TigerTixContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
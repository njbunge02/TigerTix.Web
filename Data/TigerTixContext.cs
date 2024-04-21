using Microsoft.EntityFrameworkCore;

namespace TigerTix.Web.Data
{
    public class TigerTixContext : DbContext
    {
        public DbSet<Entities.User> Users {get;set;}
        public DbSet<Entities.Event> Events {get;set;}
        public DbSet<Entities.Purchase> Purchases { get; set; }
        public DbSet<Entities.Discount> Discounts { get; set; }

        private readonly IConfiguration _config;

        public TigerTixContext(IConfiguration config)
        {
            _config = config;
        
        //Deletes All tables
        /*
            Users.RemoveRange(Users);
            Events.RemoveRange(Events);
            SaveChanges();
        */
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }

    }
}
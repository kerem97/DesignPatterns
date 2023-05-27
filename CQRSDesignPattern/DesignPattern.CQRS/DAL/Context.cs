using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1MSR6CD\\SQLEXPRESS;initial catalog=DesignPattern2Db;integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
    }
}

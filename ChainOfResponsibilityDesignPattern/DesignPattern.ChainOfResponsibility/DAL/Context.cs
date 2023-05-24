using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1MSR6CD\\SQLEXPRESS;initial catalog=DesignPattern1Db;integrated security=true");

        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}

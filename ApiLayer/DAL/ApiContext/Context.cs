using ApiLayer.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiLayer.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ERHAN\\SQLEXPRESS;database=DbCoreProject2;integrated security=true");
        }


        public DbSet<Category> Categories { get; set; }
    }
}

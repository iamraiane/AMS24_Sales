using Microsoft.EntityFrameworkCore;
using AMS3A_SalesAPI.Domain;

namespace AMS3A_SalesAPI.Context
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext>options) : base (options){ 

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product {  get; set; }
    }
}

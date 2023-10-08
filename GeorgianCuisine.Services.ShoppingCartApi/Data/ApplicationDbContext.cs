using Microsoft.EntityFrameworkCore;

namespace GeorgianCuisine.Services.ShoppingCartApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public virtual DbSet<Product> Products { get; set; }
    }
}

using GeorgianCuisine.Services.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeorgianCuisine.Services.ProductApi.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public virtual DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 1,
				Name = "Khachapuri",
				Price = 15,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://georgiancuisine.blob.core.windows.net/georgiancuisine/khachapuri.jpg",
				CategoryName = "Appetizer"
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 2,
				Name = "Mtsvadi",
				Price = 13.99,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://georgiancuisine.blob.core.windows.net/georgiancuisine/mtsvadi.jpg",
				CategoryName = "Appetizer"
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 3,
				Name = "Khinkali",
				Price = 10.99,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://georgiancuisine.blob.core.windows.net/georgiancuisine/khinkali.jpg",
				CategoryName = "Dessert"
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 4,
				Name = "Salad",
				Price = 15,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://georgiancuisine.blob.core.windows.net/georgiancuisine/salad.jpg",
				CategoryName = "Entree"
			});
		}
	}
}

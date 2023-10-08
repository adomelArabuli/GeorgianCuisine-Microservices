using GeorgianCuisine.Web.Services;
using GeorgianCuisine.Web.Services.IServices;

namespace GeorgianCuisine.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddHttpClient<IProductService, ProductService>();
			//StaticDetails.ProductApiBaseUrl = builder.Configuration["ServiceUrls:ProductApi"];
			StaticDetails.ProductApiBaseUrl = builder.Configuration.GetSection("ServiceUrls:ProductApi").Get<string>();
			
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddControllersWithViews();

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Cookies";
				options.DefaultChallengeScheme = "oidc";
			})
				.AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
				.AddOpenIdConnect("oidc", options =>
				{
					options.Authority = builder.Configuration.GetSection("ServiceUrls:IdentityApi").Get<string>();
					options.GetClaimsFromUserInfoEndpoint = true;
					options.ClientId = "georgianCuisine";
					options.ClientSecret = "secret";
					options.ResponseType = "code";

					options.TokenValidationParameters.NameClaimType = "name";
					options.TokenValidationParameters.RoleClaimType = "role";
					options.Scope.Add("georgianCuisine");
					options.SaveTokens = true;
				});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
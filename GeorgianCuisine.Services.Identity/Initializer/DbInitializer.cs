using GeorgianCuisine.Services.Identity.Data;
using GeorgianCuisine.Services.Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeorgianCuisine.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            if (await _roleManager.FindByNameAsync(StaticDetails.Admin) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticDetails.Admin));
                await _roleManager.CreateAsync(new IdentityRole(StaticDetails.Customer));
            }
            else return;

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "577509105",
                FirstName = "Ado",
                LastName = "admin"
            };

            await _userManager.CreateAsync(adminUser, "Admin123*");
            await _userManager.AddToRoleAsync(adminUser, StaticDetails.Admin);

            var temp1 = await _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName+" "+ adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, StaticDetails.Admin),
            });

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer1@gmail.com",
                Email = "customer1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "577509105",
                FirstName = "Ado",
                LastName = "customer"
            };

            await _userManager.CreateAsync(customerUser, "Customer123*");
            await _userManager.AddToRoleAsync(customerUser, StaticDetails.Customer);

            var temp2 = await _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, customerUser.FirstName+" "+ customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
                new Claim(JwtClaimTypes.Role, StaticDetails.Customer),
            });
        }
    }
}

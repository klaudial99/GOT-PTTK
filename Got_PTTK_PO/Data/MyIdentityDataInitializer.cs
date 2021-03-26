using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Got_PTTK_PO.Data
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Turysta").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Turysta",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Przodownik").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Przodownik",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Przewodnik").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Przewodnik",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedOneUser(UserManager<IdentityUser> userManager, string name, string password, string role = null)
        {
            if (userManager.FindByNameAsync(name).Result == null)
            {

                IdentityUser user = new IdentityUser
                {
                    UserName = name,
                    Email = name,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }
            }
            
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            SeedOneUser(userManager, "normaluser@localhost", "nUpass1!");
            SeedOneUser(userManager, "admin@localhost", "aUpass1!", "Admin");
            SeedOneUser(userManager, "touristuser@localhost", "tUpass1!", "Turysta");
            SeedOneUser(userManager, "turysta1@localhost", "Turysta1!", "Turysta");
            SeedOneUser(userManager, "turysta2@localhost", "Turysta2!", "Turysta");
            SeedOneUser(userManager, "turysta3@localhost", "Turysta3!", "Turysta");
            SeedOneUser(userManager, "przodownik1@localhost", "Przod1!", "Przodownik");
            SeedOneUser(userManager, "przodownik2@localhost", "Przod2!", "Przodownik");
            SeedOneUser(userManager, "przewodnik1@localhost", "Przew1!", "Przewodnik");
            SeedOneUser(userManager, "przewodnik2@localhost", "Przew2!", "Przewodnik");
        }
    }
}

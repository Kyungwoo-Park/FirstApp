using FirstApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Data
{
    public class DbSeeder
    {
        private readonly FirstAppContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbSeeder(FirstAppContext context,
                        UserManager<ApplicationUser> userManager,
                        RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedDatabase()
        {
            if (!_context.Teachers.Any())
            {
                List<Teacher> teachers = new List<Teacher>()
                {
                    new Teacher() { Name="Iron man", Class="Trade Military"},
                    new Teacher() { Name="Super man", Class="Power Usage"},
                    new Teacher() { Name="Batman", Class="Economy Concept"},
                    new Teacher() { Name="Joker", Class="Lifes Philosophy"}
                };

                await _context.AddRangeAsync(teachers);
                await _context.SaveChangesAsync();
            }

            var adminAccount = await _userManager.FindByNameAsync("admin@gmail.com");
            var adminRole = new IdentityRole("Admin");
            await _roleManager.CreateAsync(adminRole);
            await _userManager.AddToRoleAsync(adminAccount, adminRole.Name);
        }
    }
}

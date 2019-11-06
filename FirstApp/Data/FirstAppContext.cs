using FirstApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Data
{
    public class FirstAppContext : IdentityDbContext<ApplicationUser>
    {
        public FirstAppContext(DbContextOptions options) : base(options) {}

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}

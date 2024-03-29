﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data;
using FirstApp.Data.Repositories;
using FirstApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FirstAppContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("FirstAppConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<FirstAppContext>();
            services.AddTransient<DbSeeder>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

            seeder.SeedDatabase().Wait();
        }
    }
}

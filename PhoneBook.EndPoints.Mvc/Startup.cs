using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Domain.Contrants.People;
using PhoneBook.Domain.Contrants.Phones;
using PhoneBook.Domain.Contrants.Tags;
using PhoneBook.EndPoints.Mvc.Models.AAA;
using PhoneBook.Infrastucture.DataLayer.Common;
using PhoneBook.Infrastucture.DataLayer.People;
using PhoneBook.Infrastucture.DataLayer.Phones;
using PhoneBook.Infrastucture.DataLayer.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddDbContext<PhoneBookContext>(c => c.UseSqlServer(Configuration.GetConnectionString("phoneBook")));
            services.AddDbContext<UserDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("AAA")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidator>();

            services.AddScoped<IUserValidator<AppUser>, MyUserValidator>();
            services.AddIdentity<AppUser, MyIdentityRole>(c=>{
                c.Password.RequireDigit = false;
                c.Password.RequireUppercase = false;
                c.Password.RequiredLength = 6;
                c.Password.RequireLowercase = false;
                c.Password.RequiredUniqueChars =1;
            }).AddEntityFrameworkStores<UserDbContext>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Exception");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
              

        }
    }
}

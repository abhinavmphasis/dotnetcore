using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using bookslib.Data;
using bookslib.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace bookslib
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server =LAPTOP-VOTKUAG6\\MSSQLSERVER2; Database = BookStore; Integrated Security = true; "));
            services.AddControllersWithViews();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BookStoreContext>();

#if DEBUG

            services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(option=> {
                option.HtmlHelperOptions.ClientValidationEnabled = false;
            });
#endif 
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
          
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
               // endpoints.MapControllerRoute(
            //        name: "Default",
            //        pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}

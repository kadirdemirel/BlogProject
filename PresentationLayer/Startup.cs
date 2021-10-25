using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

        //    services.AddSession();

            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryDal, EfCategoryRepository>();

            services.AddSingleton<IBlogService, BlogManager>();
            services.AddSingleton<IBlogDal, EfBlogRepository>();

            services.AddSingleton<ICommentService, CommentManager>();
            services.AddSingleton<ICommentDal, EfCommentRepository>();

            services.AddSingleton<IWriterService, WriterManager>();
            services.AddSingleton<IWriterDal, EfWriterRepository>();

            services.AddSingleton<INewsLetterService, NewsLetterManager>();
            services.AddSingleton<INewsLetterDal, EfNewsLetterRepository>();

            services.AddSingleton<ICityService, CityManager>();
            services.AddSingleton<ICityDal, EfCityRepository>();

            services.AddSingleton<IAboutService, AboutManager>();
            services.AddSingleton<IAboutDal, EfAboutRepository>();

            services.AddSingleton<IContactService, ContactManager>();
            services.AddSingleton<IContactDal, EfContactRepository>();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                           .RequireAuthenticatedUser()//Kullanýcý authentica et
                           .Build();//oluþtur inþa et
                config.Filters.Add(new AuthorizeFilter(policy));


            });

            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseStatusCodePages();//Durum kodlarý için ekledik.

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Page404", "?code={0}");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

        //    app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

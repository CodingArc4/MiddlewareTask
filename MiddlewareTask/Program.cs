using Microsoft.EntityFrameworkCore;
using MiddlewareTask.Filter;
using MiddlewareTask.Middleware;
using MiddlewareTask.Models;

namespace MiddlewareTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>  {
                options.Filters.Add<ResponseFilter>();
            });

            //For database connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseMiddleware<ResponseMiddleware>();

            app.UseHttpsRedirection();

           app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Response}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
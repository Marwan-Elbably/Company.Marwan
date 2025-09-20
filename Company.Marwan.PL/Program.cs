using Company.Marwan.BLL.Interfaces;
using Company.Marwan.BLL.Reposatires;
using Company.Marwan.DAL.Data.contexts;
using Microsoft.EntityFrameworkCore;

namespace Company.Marwan.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>(); // Allow DI for Department repo
            builder.Services.AddDbContext<CompanyDbcontext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));



            } );
            
            // Allow DI for CompanyDbContext
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

            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

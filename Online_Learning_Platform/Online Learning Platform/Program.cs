using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Online_Learning_Platform.Data;
using Online_Learning_Platform.Models;
using Online_Learning_Platform.Repositories;
using Online_Learning_Platform.Repository;
using Online_Learning_Platform.Repository.Online_Learning_Platform.Repository;
public class Program
  
  {
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //Framwork service :already decalre ,alraedy register
        //built in service :already delcare ,need to register
        // Add services to the container.//Day8
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
        });
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
        });
      
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IRepository<Instructor>, InstructorRepository>(); 
        builder.Services.AddScoped<IRepository<Track>, TrackRepository>(); 
        builder.Services.AddScoped<IRepository<Course>, CourseRepository>();

        builder.Services.AddIdentity<AppliactionUser, IdentityRole>(option =>
        {
            option.Password.RequiredLength = 6;
            option.Password.RequireDigit = true;
            option.Password.RequireNonAlphanumeric = false;
            option.Password.RequireUppercase = false;

        }






        )
        .AddEntityFrameworkStores<ApplicationDbContext>();


        var app = builder.Build();


        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseSession();

        app.UseRouting();
        app.UseAuthentication();// cookie

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        //app.Map("/djhsdjh", (app) => { });

        app.Run();
    }



}

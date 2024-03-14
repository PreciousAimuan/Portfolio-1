using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Helpers;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.Repository;
using SQ20.Net_Wee7_8_Task.Services;


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

           /* builder.Services.AddScoped<IClubRepository, ClubRepository>();*/
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IPhotoService, PhotoService>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<IAboutRepository, AboutRepository>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            //Seed the app once
            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                Seed.SeedData(app);
                await Seed.SeedUsersAndRolesAsync(app);
            }

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructere.Extensions;

public static class ApplicationExtension
{
    public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
    {
        var context = app
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<RepositoryContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }

    public static void ConfigureLocalization(this WebApplication app)
    {
        app.UseRequestLocalization(options =>
        options.AddSupportedCultures("tr-TR")
        .AddSupportedUICultures("tr-TR")
        .SetDefaultCulture("tr-TR"));
    }
    public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
    {
        const string ADMIN_USER = "Admin";
        const string ADMIN_PASSWORD = "admin+123";

        // UserManager
        UserManager<IdentityUser> userManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

        // RoleManager
        RoleManager<IdentityRole> roleManager = app
            .ApplicationServices
            .CreateAsyncScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        try
        {
            IdentityUser user = await userManager.FindByNameAsync(ADMIN_USER);
            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "omer@gmail.com",
                    PhoneNumber = "5536972626",
                    UserName = ADMIN_USER
                };

                var result = await userManager.CreateAsync(user, ADMIN_PASSWORD);
                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not created." + user.Email);
                }

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r => r.Name)
                        .ToList()
                );

                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for admin.");

            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message) ;
        }


    }
}
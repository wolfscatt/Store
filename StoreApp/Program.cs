
using StoreApp.Infrastructere.Extensions;

var builder = WebApplication.CreateBuilder(args);

// API
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();

// -------------------------------- ServiceExtension --------------------------------
// Session (oturum) Injection
builder.Services.ConfigureSession();
// Repositories Layer Injection
builder.Services.ConfigureRepositoryRegistration();
// Services Layer Injection
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();


builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

// oturum açma ve yetkilendirme işlemleri routing ile endpoint arasında yazılmalıdır.
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>{
    endpoints.MapAreaControllerRoute("Admin","Admin","Admin/{controller=Dashboard}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();
app.Run();

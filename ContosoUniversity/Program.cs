using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ContosoUniversity.Services;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSystemWebAdapters()
    .AddWrappedAspNetCoreSession()
    .AddJsonSessionSerializer(options =>
    {
        options.RegisterKey<string>("MachineName");
        options.RegisterKey<string>("SessionStartTime");
    })
    .AddHttpApplication<MvcApplication>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<NotificationService>();

// Configure Entity Framework
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Initialize database (moved from Global.asax.cs)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SchoolContext>();
    DbInitializer.Initialize(context);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Global error handler
    app.UseStatusCodePagesWithReExecute("/Home/StatusErrorCode", "?code={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseSystemWebAdapters();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")


app.Run();
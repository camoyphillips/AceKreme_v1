using AceKreme_v1.Data;
using AceKreme_v1.Interfaces;
using AceKreme_v1.Models;
using AceKreme_v1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// DATABASE CONNECTION for AceKreme_v1
var cs = builder.Configuration.GetConnectionString("DefaultConnection")
         ?? throw new InvalidOperationException("DefaultConnection missing");
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(cs));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ASP.NET IDENTITY for AceKreme_v1
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// DEPENDENCY INJECTION for AceKreme_v1 (Business Services)
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();

// PAYPAL CONFIGURATION for AceKreme_v1
builder.Services.Configure<PayPalSettings>(builder.Configuration.GetSection("PayPal"));

//MVC + RAZOR PAGES for AceKreme_v1
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// SWAGGER (requires Swashbuckle.AspNetCore) for AceKreme_v1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AceKreme_v1 API",
        Version = "v1"
    });
});

var app = builder.Build();

// APPLY DATABASE MIGRATIONS AUTOMATICALLY AT STARTUP for AceKreme_v1
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.MigrateAsync();
}

// MIDDLEWARE PIPELINE for AceKreme_v1
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    // Swagger UI for AceKreme_v1
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AceKreme_v1 API v1");
        c.RoutePrefix = "swagger"; 
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

// DEFAULT CONTROLLER ROUTE for AceKreme_v1
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//RAZOR PAGES for AceKreme_v1 
app.MapRazorPages();

// RUN THE APP for AceKreme_v1
app.Run();

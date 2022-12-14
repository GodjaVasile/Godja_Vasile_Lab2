using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Godja_Vasile_Lab2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(
    options =>
    {
        options.Conventions.AuthorizeFolder("/Books/Create", "AdminPolicy");
        options.Conventions.AllowAnonymousToPage("/Books/Index");
        options.Conventions.AllowAnonymousToPage("/Books/Details");
        options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
        options.Conventions.AuthorizeFolder("/Publishers/Create", "AdminPolicy");
        options.Conventions.AuthorizeFolder("/Categories/Create", "AdminPolicy");
    });
builder.Services.AddDbContext<Godja_Vasile_Lab2Context>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Godja_Vasile_Lab2Context") ??
throw new InvalidOperationException("Connectionstring 'Godja_Vasile_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Godja_Vasile_Lab2Context") ??
throw new InvalidOperationException("Connectionstring 'Godja_Vasile_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();

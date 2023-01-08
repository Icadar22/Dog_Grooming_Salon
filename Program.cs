using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dog_Grooming_Salon.Data;
using Microsoft.AspNetCore.Identity;
using Dog_Grooming_Salon.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Dogs");
    options.Conventions.AllowAnonymousToPage("/Dogs/Index");
    options.Conventions.AllowAnonymousToPage("/Dogs/Details");
    options.Conventions.AllowAnonymousToPage("/Services/Details");
    options.Conventions.AuthorizeFolder("/Owners", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Genders", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Breeds", "AdminPolicy");
}); 
builder.Services.AddDbContext<Dog_Grooming_SalonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dog_Grooming_SalonContext") ?? throw new InvalidOperationException("Connection string 'Dog_Grooming_SalonContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Dog_Grooming_SalonContext") ?? throw new InvalidOperationException("Connectionstring 'Dog_Grooming_SalonContext' not found.")));
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

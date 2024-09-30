using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Zara_GestionDVD.Data;
using Zara_GestionDVD.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services pour les contrôleurs et les vues
builder.Services.AddControllersWithViews();

// Configurer le DbContext avec SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajouter Identity pour gérer l'authentification des utilisateurs
builder.Services.AddIdentity<Utilisateur, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ajouter l'authentification et l'autorisation
app.UseAuthentication();
app.UseAuthorization();

// Configurer les routes pour le contrôleur Account
app.MapControllerRoute(
    name: "account",
    pattern: "Account/{action=Login}/{id?}",
    defaults: new { controller = "Account", action = "Login" }
);

// Route par défaut
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DVDs}/{action=Index}/{id?}");

app.Run();
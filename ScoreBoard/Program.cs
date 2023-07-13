using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CatalogueDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:CatalogueGateauxDbContextConnection"]);
});
builder.Services.AddScoped<IJoueurRepository,DBJoueurRepository>();
builder.Services.AddScoped<IJeuRepository,DBJeuRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Joueur}/{action=Index}/{id?}");

InitialisateurBD.Seed(app);

app.Run();

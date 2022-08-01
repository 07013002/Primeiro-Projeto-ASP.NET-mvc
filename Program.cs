using Microsoft.EntityFrameworkCore;
using ProcessoSeleticov2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer("Server=./;Database=DB_SistemaProcessos;Initial Catalog=ProcessoSeletivo3;User id=sa;Password=25879"));


var app = builder.Build();

//builder.Services.AddEntityFrameworkSqlServer()
 //   .AddDbContext<BancoContext>(o => o.UseSqlServer(builder.GetConnectionString("DataBase")));

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

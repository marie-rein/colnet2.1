using ColNet2._0.Authentification;
using ColNet2._0.Data;
using ColNet2._0.Services;
using ColNet2._0.CustomModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Net.Security;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

var consStringBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("Connexion_BD_William_Marie-Reine"));
consStringBuilder.Password = builder.Configuration["password"];

builder.Services.AddPooledDbContextFactory<_2023Prog3WilliamMarieReineContext > (
    x => x.UseSqlServer(consStringBuilder.ConnectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSyncfusionBlazor();

//service d'authentification

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthenticationCore();

builder.Services.AddScoped<leService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ResetPasswordService>();
builder.Services.AddScoped<AjoutUtilisateurService>();
builder.Services.AddScoped<NotesService>();
builder.Services.AddScoped<AjoutEvaluationService>();
builder.Services.AddScoped<GetLoggedUser>();







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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

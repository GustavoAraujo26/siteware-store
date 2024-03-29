using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SitewareStore.Data;
using SitewareStore.Infra.Data.Extensions;
using SitewareStore.Domain.Extensions;
using SitewareStore.Service.Extensions;
using SitewareStore.Infra.CrossCutting.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.ConfigureStoreAutoMapper();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureDbConnectionString();
builder.Services.AddSingleton<UserShoppingCartService>();

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

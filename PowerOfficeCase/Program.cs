using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PowerOfficeCase.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseStaticWebAssets();

builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped(servisProvider => 
    new HttpClient { BaseAddress = new Uri(builder.Configuration["Brreg:ApiBaseUrl"])});
builder.Services.AddHttpClient<IBrregDataService, BrregDataService>(
    httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["Brreg:ApiBaseUrl"]));

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

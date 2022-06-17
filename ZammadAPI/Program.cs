using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ZammadAPI.Data;
using ZammadAPI.Infrastructure.Abstraction;
using ZammadAPI.Infrastructure.Abstraction.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IHttpService, HttpService>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ZammadUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<CustomHttpContext>();
builder.Services.AddTransient<SecurePasswordHasher>();


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

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorAppM1GL.Data;
using BlazorAppM1GL.Models;

var builder = WebApplication.CreateBuilder(args);

// Charger configuration
var configuration = builder.Configuration;

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Services
builder.Services.AddScoped<IMemoireService, MemoireService>();

// Blazor Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<BlazorAppM1GL.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
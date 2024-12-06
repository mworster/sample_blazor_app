using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using StockReader.Models;
using StockReader;
using StockReader.Services;
using Blazored.SessionStorage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<StockInfoService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthorizationService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

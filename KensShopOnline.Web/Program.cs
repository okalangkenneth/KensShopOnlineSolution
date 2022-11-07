using KensShopOnline.Web;
using KensShopOnline.Web.Services.Contracts;
using KensShopOnline.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7060/") });

builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();

global using BlazorEcommerce.Client;
global using BlazorEcommerce.Shared;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using BlazorEcommerce.Client.Services.ProductService;
global using BlazorEcommerce.Client.Services.CategoryService;
using Blazored.LocalStorage;
using BlazorEcommerce.Client.Services.CartService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();

await builder.Build().RunAsync();

using eShop.WebApp.Components;
using eShop.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.AddApplicationServices();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAntiforgery();

app.UseStaticFiles();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

//  first argument is the pattern for the incoming request path
//  second argument is the address of the server to forward the request to
// the last argument is the target path on the forwarded server
app.MapForwarder("/product-images/{id}", "http://catalog-api", "/api/catalog/items/{id}/pic");

app.Run();

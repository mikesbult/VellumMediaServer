using VellumMediaServerF.Frontend.Clients;
using VellumMediaServerF.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

/*var VellumMediaServerFApiUrl = builder.Configuration["VellumMediaServerFApiUrl"] ??
    throw new Exception("VellumMediaServerFApiUrl is not set");*/

    // 1. Checks Render first for the environment variable 'ApiBaseUrl'
// 2. Falls back to your local appsettings.json string if you are running locally
var VellumMediaServerFApiUrl = Environment.GetEnvironmentVariable("ApiBaseUrl") 
                              ?? builder.Configuration["VellumMediaServerFApiUrl"]
                              ?? "http://localhost:5249";

builder.Services.AddHttpClient<MediaClient>(
    client => client.BaseAddress = new Uri(VellumMediaServerFApiUrl));

    builder.Services.AddHttpClient<CategorysClient>(    
    client => client.BaseAddress = new Uri(VellumMediaServerFApiUrl));


/*builder.Services.AddHttpClient<MediaClient>(client => 
{
    client.BaseAddress = new Uri("http://localhost:5249/"); 
});*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();

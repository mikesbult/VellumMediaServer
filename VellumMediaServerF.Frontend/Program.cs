using VellumMediaServerF.Frontend.Clients;
using VellumMediaServerF.Frontend.Components;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiBaseUrl =
    Environment.GetEnvironmentVariable("ApiBaseUrl")
    ?? builder.Configuration["VellumMediaServerFApiUrl"]
    ?? "http://localhost:5249/";

apiBaseUrl = apiBaseUrl.TrimEnd('/') + "/";

builder.Services.AddHttpClient<MediaClient>(c => c.BaseAddress = new Uri(apiBaseUrl));
builder.Services.AddHttpClient<CategorysClient>(c => c.BaseAddress = new Uri(apiBaseUrl));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
using GetChattyKioskInterface;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("PingOneAPI", client =>
{
    client.BaseAddress = new Uri("https://api.pingone.com/v1/environments/36725f85-9297-4833-9cca-d7f9b180c7a6/");
})
.AddHttpMessageHandler(sp =>
{
    var handler = sp.GetRequiredService<AuthorizationMessageHandler>()
        .ConfigureHandler(
            authorizedUrls: ["https://api.pingone.com/v1/environments/36725f85-9297-4833-9cca-d7f9b180c7a6"],
            scopes: ["openid", "profile", "email", "p1:read:user", "p1:read:userConsent", "p1:read:sessions"] 
        );
    return handler;
});

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("PingOneAPI"));


builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("OpenIdConnect", options.ProviderOptions);
});

await builder.Build().RunAsync();

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace weavy_blazor_telerik.Client {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("ServerAPI", client => {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

            // weavy api 
            builder.Services.AddScoped<WeavyAuthorizationMessageHandler>();

            builder.Services.AddHttpClient("WeavyAPI", client => {
                client.BaseAddress = new Uri("https://showcase.weavycloud.com");
            }).AddHttpMessageHandler<WeavyAuthorizationMessageHandler>();

            // register the Telerik services
            builder.Services.AddTelerikBlazor();

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }

    public class WeavyAuthorizationMessageHandler : AuthorizationMessageHandler {

        public WeavyAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager) : base(provider, navigationManager) {
            ConfigureHandler(authorizedUrls: new[] { "https://showcase.weavycloud.com" }, scopes: null);
        }
    }
}

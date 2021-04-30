using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace weavy_blazor_telerik.Server.Models {
    public class WeavyAuthorizationMessageHandler : AuthorizationMessageHandler {

        public WeavyAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager) {
            ConfigureHandler(
                authorizedUrls: new[] { "https://www.example.com/base" },
                scopes: new[] { "example.read", "example.write" });
        }
    }
}

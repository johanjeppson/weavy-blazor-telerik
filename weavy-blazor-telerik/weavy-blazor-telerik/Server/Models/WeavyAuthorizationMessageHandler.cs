using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace weavy_blazor_telerik.Server.Models {
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler {

        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager) {
            ConfigureHandler(
                authorizedUrls: new[] { "https://www.example.com/base" },
                scopes: new[] { "example.read", "example.write" });
        }
    }
}

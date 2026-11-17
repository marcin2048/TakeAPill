using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TakeAPill.Components.Account.Pages;
using TakeAPill.Infrastructure.Data;

namespace TakeAPill.Components.Account;

internal static class IdentityComponentsEndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapAdditionalIdentityEndpoints(
        this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("Account/PerformExternalLogin", (
            HttpContext context,
            [FromForm] string provider,
            [FromForm] string returnUrl,
            [FromServices] SignInManager<ApplicationUser> signInManager) =>
        {
            IEnumerable<KeyValuePair<string, StringValues>> query = [
                new("ReturnUrl", returnUrl),
                    new("Action", ExternalLogin.LoginCallbackAction)];

            var redirectUrl = UriHelper.BuildRelative(
                context.Request.PathBase,
                "/Account/ExternalLogin",
                QueryString.Create(query));

            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Results.Challenge(properties, [provider]);
        });

        endpoints.MapPost("Account/Logout", async (
            [FromForm] string returnUrl,
            [FromServices] SignInManager<ApplicationUser> signInManager) =>
        {
            await signInManager.SignOutAsync();
            return Results.LocalRedirect("~/" + returnUrl);
        });

        return endpoints;
    }
}

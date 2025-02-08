using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SingletonPattern.API.Filters
{
    public class ClientAuthenticationAttribute : ActionFilterAttribute
    {
        private const string ClientIdHeader = "X-Client-Id";
        private const string ClientSecretHeader = "X-Client-Secret";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            if (!context.HttpContext.Request.Headers.TryGetValue(ClientIdHeader, out var clientId) ||
                !context.HttpContext.Request.Headers.TryGetValue(ClientSecretHeader, out var clientSecret))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Validate credentials against configuration or database
            if (!ValidateCredentials(clientId, clientSecret, configuration))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }

        private bool ValidateCredentials(string clientId, string clientSecret, IConfiguration configuration)
        {
            // Get valid credentials from configuration
            var validClientId = configuration["ClientAuthentication:ClientId"];
            var validClientSecret = configuration["ClientAuthentication:ClientSecret"];

            return clientId.Equals(validClientId) && clientSecret.Equals(validClientSecret);
        }

    }
}

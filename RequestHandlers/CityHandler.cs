using Microsoft.AspNetCore.Authorization;

namespace MVC_Roles.RequestHandlers
{
    public class CityHandler : AuthorizationHandler<CityRequarement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CityRequarement requirement)
        {
            if(context.User.HasClaim("CityRogachev", "Рогачев"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}

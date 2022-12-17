using Microsoft.AspNetCore.Authorization;
using MVC_Roles.Models;
using System.Security.Claims;

namespace MVC_Roles.RequestHandlers
{
    public class DataOfBirthHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var dataOfbirt = context.User;
            var claim = context.User.FindFirst("MinimumDataOfBirdth");
            if (claim != null)
            {
                var birthDay = Convert.ToInt32(claim?.Value);
                if(birthDay >= requirement.MinAge)
                {
                    context.Succeed(requirement);
                };
            }
           
            return Task.CompletedTask;
        }
    }
}

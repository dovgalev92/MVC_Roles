using Microsoft.AspNetCore.Authorization;

namespace MVC_Roles.RequestHandlers
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int minimumAge)
        {
            MinAge = minimumAge;
        }

        public int MinAge { get; }
        
    }
}

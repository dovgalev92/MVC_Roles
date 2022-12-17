using Microsoft.AspNetCore.Authorization;

namespace MVC_Roles.RequestHandlers
{
    public class CityRequarement : IAuthorizationRequirement
    {
        public CityRequarement(string city) { City = city; }
        public string City { get; set; }
    }
}

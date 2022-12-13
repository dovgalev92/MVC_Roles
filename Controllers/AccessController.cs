using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Roles.Context;
using MVC_Roles.Models;
using System.Security.Claims;

namespace MVC_Roles.Controllers
{
    [Route("{controller}")]
    public class AccessController : Controller
    {
        private readonly Context_Data context;
        public AccessController(Context_Data context)
        {
            this.context = context;
        }
        [Route("Login")]
        public async Task<IActionResult> LogIn(LoginUser login)
        {
            if (ModelState.IsValid)
            {
                var user = await context.Users.Include(r => r.Roles)
                    .Where(u => u.Email.Equals(login.Email) && u.Password.Equals(login.Password)).FirstOrDefaultAsync();
                if (user != null)
                {
                    await Authorisation(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(login);
        }
        
        [Route("Registr")]
        public async Task<IActionResult> RegisterUser(RegistModel regist)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users.FirstOrDefault(u => u.Email.Equals(regist.Email));
                if(user == null)
                {
                    user = new User 
                    { Email = regist.Email, 
                      Password = regist.Password 
                    };

                    Roles roles = await context.Roles.FirstOrDefaultAsync(n => n.Name == "Администратор");
                    if(roles!= null)
                    {
                        user.Roles = roles;
                    }
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    await Authorisation(user);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(regist);
        }



        public async Task Authorisation(User user)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Roles?.Name)
            };
            var claimIdentity = new ClaimsIdentity(claim, "Cookies", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimIdentity));
        }
    }
    
}

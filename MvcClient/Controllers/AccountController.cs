using Microsoft.AspNetCore.Mvc;

namespace MvcClient.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
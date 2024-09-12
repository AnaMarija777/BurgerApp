using Microsoft.AspNetCore.Mvc;

namespace BurgerShop.WebApp.Controllers
{
    [Route("")]
    public class BurgerController : Controller
    {

        [HttpGet("ShowAllBurgers")]
        public IActionResult ShowAllBurgers()
        {
            return View();
        }

        [HttpPost("ShowAllBurgers")]
        public IActionResult ShowAllBurgers()
        {

        }
    }
}

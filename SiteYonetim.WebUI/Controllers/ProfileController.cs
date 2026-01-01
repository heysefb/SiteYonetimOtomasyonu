using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteYonetim.Business.Abstract;
using System.Linq;

namespace SiteYonetim.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDuesService _duesService;

        public ProfileController(IUserService userService, IDuesService duesService)
        {
            _userService = userService;
            _duesService = duesService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var userIdString = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Index", "Login");
            }
            int id = int.Parse(userIdString);
            var user = _userService.TGetByID(id);
            return View(user);
        }
        [HttpGet]
        public IActionResult MyDues()
        {
            var userIdString = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                return RedirectToAction("Index", "Login");
            }
            int id = int.Parse(userIdString);
            var dues = _duesService.TGetListByUserId(id);
            return View(dues);
        }
    }
}
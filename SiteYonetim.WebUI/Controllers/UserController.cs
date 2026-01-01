using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteYonetim.Business.Abstract;
using SiteYonetim.Entity.Concrete;
namespace SiteYonetim.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var values = _userService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User p)
        {
            if (ModelState.IsValid)
            {
                _userService.TInsert(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult DeleteUser(int id)
        {
            var value = _userService.TGetByID(id);
            _userService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var value = _userService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateUser(User p)
        {
            if (ModelState.IsValid)
            {
                _userService.TUpdate(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}
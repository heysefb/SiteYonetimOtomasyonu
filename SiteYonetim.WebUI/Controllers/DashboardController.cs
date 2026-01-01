using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteYonetim.Business.Abstract;
using System.Linq;

namespace SiteYonetim.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDuesService _duesService;
        private readonly IApartmentService _apartmentService;

        public DashboardController(IUserService userService, IDuesService duesService, IApartmentService apartmentService)
        {
            _userService = userService;
            _duesService = duesService;
            _apartmentService = apartmentService;
        }

        public IActionResult Index()
        {
            ViewBag.ToplamDaire = _apartmentService.TGetList().Count();
            ViewBag.DoluDaire = _apartmentService.TGetList().Where(a => a.UserId != null).Count();
            ViewBag.BosDaire = _apartmentService.TGetList().Where(a => a.UserId == null).Count();
            ViewBag.ToplamKullanici = _userService.TGetList().Count();
            var kasa = _duesService.TGetList().Where(d => d.IsPaid == true).Sum(d => d.Amount);
            ViewBag.Kasa = kasa;
            var alacak = _duesService.TGetList().Where(d => d.IsPaid == false).Sum(d => d.Amount);
            ViewBag.Alacak = alacak;

            return View();
        }
    }
}
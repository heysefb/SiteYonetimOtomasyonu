using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SiteYonetim.Business.Abstract;
using DocumentFormat.OpenXml.Wordprocessing;

namespace SiteYonetim.WebUI.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IDuesService _duesService;

        public PaymentController(IDuesService duesService)
        {
            _duesService = duesService;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var payments = _duesService.TGetByID(id);
            if (payments.IsPaid)
            {
                return RedirectToAction("MyDues", "Profile");
            }
            ViewBag.DuesId = payments.Id;
            ViewBag.Amount = payments.Amount;
            ViewBag.Description = $"{payments.Month}/{payments.Year} Dönemi Aidat Ödemesi";
            return View();
        }
        [HttpPost]
        public IActionResult Index(int duesId, string cardNumber, string cardHolder)
        {
            var payment = _duesService.TGetByID(duesId);
            payment.IsPaid = true;
            _duesService.TUpdate(payment);
            TempData["PaymentSuccess"] = "Ödemeniz başarıyla gerçekleştirilmiştir.";
            return RedirectToAction("MyDues", "Profile");
        }

    }
}
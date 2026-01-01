using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteYonetim.Business.Abstract;
using SiteYonetim.Entity.Concrete;
using System;
using System.Linq;

namespace SiteYonetim.WebUI.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Inbox()
        {
            var mail = User.Identity.Name;
            var values = _messageService.TGetList().Where(x => x.ReceiverMail == mail)
            .OrderByDescending(x => x.Date)
            .ToList();
            return View(values);
        }
        public IActionResult Sendbox()
        {
            var mail = User.Identity.Name;
            var values = _messageService.TGetList().Where(x => x.SenderMail == mail)
            .OrderByDescending(x => x.Date)
            .ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult SendMessage(string aliciMail = "null")
        {
            ViewBag.aliciMail = aliciMail;
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message p)
        {
            var mail = User.Identity.Name;
            p.SenderMail = mail;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.IsRead = false;
            _messageService.TInsert(p);
            return RedirectToAction("Sendbox");
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = _messageService.TGetByID(id);
            value.IsRead = true;
            _messageService.TUpdate(value);
            return View(value);
        }
    }
}
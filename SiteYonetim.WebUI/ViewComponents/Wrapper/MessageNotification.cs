using Microsoft.AspNetCore.Mvc;
using SiteYonetim.Business.Abstract;
using System.Linq;

namespace SiteYonetim.WebUI.ViewComponents.Wrapper
{
    public class MessageNotification : ViewComponent
    {
        private readonly IMessageService _messageService;

        public MessageNotification(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke()
        {
            var mail = User.Identity.Name;
            var unreadCount = _messageService.TGetList().Where(m => m.ReceiverMail == mail && m.IsRead == false).Count();
            return View(unreadCount);
        }
    }
}
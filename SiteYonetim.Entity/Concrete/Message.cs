using SiteYonetim.Entity.Abstract;
using System;

namespace SiteYonetim.Entity.Concrete
{
    public class Message : BaseEntity
    {
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
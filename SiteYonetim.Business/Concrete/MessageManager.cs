using SiteYonetim.Entity.Concrete;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.Business.Abstract;
using System.Collections.Generic;

namespace SiteYonetim.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }
        public Message TGetByID(int id)
        {
            return _messageDal.GetByID(id);
        }
        public List<Message> TGetList()
        {
            return _messageDal.GetListAll();
        }
        public void TInsert(Message t)
        {
            _messageDal.Insert(t);
        }
        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
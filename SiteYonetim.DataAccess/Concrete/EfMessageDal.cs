using SiteYonetim.Entity.Concrete;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.DataAccess.Concrete;

namespace SiteYonetim.DataAccess.Concrete
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
    }
}
using SiteYonetim.Entity.Concrete;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.DataAccess.Concrete;
namespace SiteYonetim.DataAccess.Abstract
{
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
    }
}
using SiteYonetim.Entity.Concrete;
using SiteYonetim.Business.Abstract;
using SiteYonetim.DataAccess.Concrete;

namespace SiteYonetim.Business.Abstract
{
    public interface IDuesService : IGenericService<Dues>
    {
        List<Dues> TGetListWithApartment();
        List<Dues> TGetListByUserId(int userId);
    }
}
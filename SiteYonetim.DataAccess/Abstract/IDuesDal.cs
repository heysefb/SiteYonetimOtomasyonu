using SiteYonetim.Entity.Concrete;
using SiteYonetim.DataAccess.Abstract;
namespace SiteYonetim.DataAccess.Abstract
{
    public interface IDuesDal : IGenericDal<Dues>
    {
        List<Dues> GetListWithApartment();
        List<Dues> GetListByUserId(int userId);
    }
}
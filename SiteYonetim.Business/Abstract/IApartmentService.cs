using SiteYonetim.Entity.Concrete;

namespace SiteYonetim.Business.Abstract
{
    public interface IApartmentService : IGenericService<Apartment>
    {
        List<Apartment> TGetApartmentListWithBlock();
    }
}
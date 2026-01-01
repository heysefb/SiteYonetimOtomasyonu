using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.Entity.Concrete;

public interface IApartmentDal : IGenericDal<Apartment>
{
    List<Apartment> GetApartmentListWithBlock();
}
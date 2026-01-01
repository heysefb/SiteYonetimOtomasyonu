using SiteYonetim.DataAccess.Concrete;
using SiteYonetim.DataAccess.Concrete.Context;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

public class EfApartmentDal : GenericRepository<Apartment>, IApartmentDal
{
    public List<Apartment> GetApartmentListWithBlock()
    {
        using var c = new SiteYonetimContext();
        return c.Apartments.Include(x => x.Block)
                            .Include(x => x.User)
                            .ToList();
    }
}
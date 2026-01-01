using SiteYonetim.Entity.Concrete;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.DataAccess.Concrete.Context;
using SiteYonetim.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
namespace SiteYonetim.DataAccess.Concrete
{
    public class EfDuesDal : GenericRepository<Dues>, IDuesDal
    {
        public List<Dues> GetListWithApartment()
        {
            using var c = new SiteYonetimContext();
            return c.Dues.Include(x => x.Apartment)
            .ThenInclude(y => y.Block) // <--- BU EKSİKSE HATA VERİR
            .Include(x => x.Apartment)
            .ThenInclude(y => y.User)  // <--- Kullanıcı adı için bu da lazım
            .ToList();
        }
        public List<Dues> GetListByUserId(int userId)
        {
            using var c = new SiteYonetimContext();
            return c.Dues.Include(x => x.Apartment)
                          .ThenInclude(a => a.Block)
                          .Where(d => d.Apartment.UserId == userId)
                          .ToList();
        }
    }
}
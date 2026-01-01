using System.Collections.Generic;
using SiteYonetim.Business.Abstract;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.Entity.Concrete;

namespace SiteYonetim.Business.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IApartmentDal _apartmentDal;

        public ApartmentManager(IApartmentDal apartmentDal)
        {
            _apartmentDal = apartmentDal;
        }

        public void TDelete(Apartment t)
        {
            _apartmentDal.Delete(t);
        }

        public Apartment TGetByID(int id)
        {
            return _apartmentDal.GetByID(id);
        }

        public List<Apartment> TGetList()
        {
            return _apartmentDal.GetListAll();
        }

        public void TInsert(Apartment t)
        {
            _apartmentDal.Insert(t);
        }

        public void TUpdate(Apartment t)
        {
            _apartmentDal.Update(t);
        }
        public List<Apartment> TGetApartmentListWithBlock()
        {
            return (_apartmentDal as IApartmentDal).GetApartmentListWithBlock();
        }
    }
}
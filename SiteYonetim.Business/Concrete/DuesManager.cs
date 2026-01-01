using SiteYonetim.Business.Abstract;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.DataAccess.Concrete;
using SiteYonetim.Entity.Concrete;
using System.Collections.Generic;

namespace SiteYonetim.Business.Concrete
{
    public class DuesManager : IDuesService
    {
        private readonly IDuesDal _duesDal;

        public DuesManager(IDuesDal duesDal)
        {
            _duesDal = duesDal;
        }

        public void TDelete(Dues t)
        {
            _duesDal.Delete(t);
        }

        public Dues TGetByID(int id)
        {
            return _duesDal.GetByID(id);
        }

        public List<Dues> TGetList()
        {
            return _duesDal.GetListAll();
        }
        public void TInsert(Dues t)
        {
            _duesDal.Insert(t);
        }

        public void TUpdate(Dues t)
        {
            _duesDal.Update(t);
        }

        public List<Dues> TGetListWithApartment()
        {

            return _duesDal.GetListWithApartment();
        }
        public List<Dues> TGetListByUserId(int userId)
        {
            return _duesDal.GetListByUserId(userId);
        }
    }
}
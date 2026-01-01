using System.Collections.Generic;
using SiteYonetim.Business.Abstract;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.Entity.Concrete;

namespace SiteYonetim.Business.Concrete
{
    public class UserManager : IUserService
    {
    private readonly IGenericDal<User> _userDal;
    public UserManager(IGenericDal<User> userDal)
    {
        _userDal = userDal;
    }
    public void TDelete(User t)
    {
        _userDal.Delete(t);
    }
    public void TInsert(User t)
    {
        _userDal.Insert(t);
    }
    public void TUpdate(User t)
    {
        _userDal.Update(t);
    }
    public User TGetByID(int id)
    {
        return _userDal.GetByID(id);
    }
    public List<User> TGetList()
    {
        return _userDal.GetListAll();
    }
    }

}
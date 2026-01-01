using System.Collections.Generic;
using SiteYonetim.Business.Abstract;
using SiteYonetim.DataAccess.Abstract;
using SiteYonetim.Entity.Concrete;

namespace SiteYonetim.Business.Concrete
{
    public class BlockManager : IBlockService
    {
        private readonly IGenericDal<Block> _blockDal;

        public BlockManager(IGenericDal<Block> blockDal)
        {
            _blockDal = blockDal;
        }
        public void TDelete(Block t)
        {
            _blockDal.Delete(t);
        }
        public Block TGetByID(int id)
        {
            return _blockDal.GetByID(id);
        }
        public List<Block> TGetList()
        {
            return _blockDal.GetListAll();
        }

        public void TInsert(Block t)
        {
            _blockDal.Insert(t);
        }
        public void TUpdate(Block t)
        {
            _blockDal.Update(t);
        }
    }
}
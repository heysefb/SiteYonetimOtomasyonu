using SiteYonetim.Entity.Abstract;

namespace SiteYonetim.Entity.Concrete
{
    public class Apartment : BaseEntity
    {
        public int BlockId { get; set; }
        public Block Block { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public bool IsOccupied { get; set; }
        public string OwnerOrTenant { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}

using SiteYonetim.Entity.Abstract;
namespace SiteYonetim.Entity.Concrete
{
    public class Dues : BaseEntity
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}

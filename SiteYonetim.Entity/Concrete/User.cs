using SiteYonetim.Entity.Abstract;
namespace SiteYonetim.Entity.Concrete
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string TCNo { get; set; }
        public string CarPlate { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
    }
}
using System.Collections.Generic;
using SiteYonetim.Entity.Abstract;

namespace SiteYonetim.Entity.Concrete
{
    public class Block : BaseEntity
    {
        public string Name { get; set; }
        public List<Apartment> Apartments { get; set; }
    }
}
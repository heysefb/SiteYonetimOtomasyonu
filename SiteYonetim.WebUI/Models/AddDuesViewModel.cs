using Microsoft.AspNetCore.Mvc.Rendering;
using SiteYonetim.Entity.Concrete;
using System.Collections.Generic;

namespace SiteYonetim.WebUI.Models
{
    public class AddDuesViewModel
    {
        public Dues Dues { get; set; } = new Dues();
        public List<SelectListItem> ApartmentList { get; set; } = new List<SelectListItem>();
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteYonetim.Entity.Concrete;

namespace SiteYonetim.WebUI.Models
{
    public class AddApartmentViewModel
    {
        public Apartment Apartment { get; set; } = new Apartment();
        public List<SelectListItem> BlockList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> UserList { get; set; } = new List<SelectListItem>();
    }
}
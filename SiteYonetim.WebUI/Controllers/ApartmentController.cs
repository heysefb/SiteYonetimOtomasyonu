using Microsoft.AspNetCore.Mvc;
using SiteYonetim.Business.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteYonetim.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace SiteYonetim.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly IBlockService _blockService;
        private readonly IUserService _userService;
        public ApartmentController(IApartmentService apartmentService, IBlockService blockService, IUserService userService)
        {
            _apartmentService = apartmentService;
            _blockService = blockService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var values = _apartmentService.TGetApartmentListWithBlock();
            return View(values);

        }
        [HttpGet]
        public IActionResult AddApartment()
        {
            List<SiteYonetim.Entity.Concrete.Block> blocks = _blockService.TGetList();
            AddApartmentViewModel model = new AddApartmentViewModel();

            model.BlockList = (from x in blocks
                               select new SelectListItem
                               {
                                   Text = x.Name,
                                   Value = x.Id.ToString()
                               }).ToList();
            model.Apartment = new SiteYonetim.Entity.Concrete.Apartment();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddApartment(AddApartmentViewModel model)
        {
            ModelState.Remove("Apartment.Block");
            ModelState.Remove("Apartment.User");
            ModelState.Remove("BlockList");
            if (ModelState.IsValid)
            {
                _apartmentService.TInsert(model.Apartment);
                return RedirectToAction("Index");
            }
            List<SiteYonetim.Entity.Concrete.Block> blocks = _blockService.TGetList();
            model.BlockList = (from x in blocks
                               select new SelectListItem
                               {
                                   Text = x.Name,
                                   Value = x.Id.ToString()
                               }).ToList();
            return View(model);
        }
        public IActionResult DeleteApartment(int id)
        {
            var value = _apartmentService.TGetByID(id);
            _apartmentService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateApartment(int id)
        {
            var value = _apartmentService.TGetByID(id);
            List<SelectListItem> blockList = (from x in _blockService.TGetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.Id.ToString()
                                              }).ToList();
            List<SelectListItem> users = (from x in _userService.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name + " " + x.Surname + " (TC: " + x.TCNo + ")",
                                              Value = x.Id.ToString()
                                          }).ToList();
            AddApartmentViewModel model = new AddApartmentViewModel
            {
                BlockList = blockList,
                UserList = users,
                Apartment = value
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateApartment(AddApartmentViewModel model)
        {
            ModelState.Remove("Apartment.Block");
            ModelState.Remove("Apartment.User");
            ModelState.Remove("BlockList");
            if (ModelState.IsValid)
            {
                _apartmentService.TUpdate(model.Apartment);
                return RedirectToAction("Index");
            }
            List<SelectListItem> blockValues = (from x in _blockService.TGetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            model.BlockList = blockValues;
            return View(model);
        }
    }
}